using Application.DTOs.Email;
using Application.DTOs.Professionals;
using Application.DTOs.Professionals.GetProfessionalDTOs;
using Application.DTOs.Professionals.UpdateProfessionalRequestDTOs;
using Application.DTOs.Users.RetrieveUserDTOs;
using Application.Services.Users;
using CrossCutting.Databases;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services.RegisterProfessionals;
using Domain.Entities.Professionals;
using Domain.Exceptions.Adresses;
using Domain.Exceptions.Professionals;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Professionals;

public class ProfessionalService(
    IProfessionalRepository professionalRepository,
    IProfessionRepository professionRepository,
    IUserService userService,
    IEmailService emailService,
    IConfiguration configuration,
    IRegisterProfessional registerProfessional,
    IAddressRepository addressRepository)
    : IProfessionalService
{
    private readonly string _frontendUrl = configuration.GetValue<string>("FrontendUrl") ??
                                           throw new InvalidOperationException(
                                               "FrontendUrl não configurada no appsettings");

    public async Task<Professional> PreRegisterWhenNotExists(PreRegisterProfessionalRequest request)
    {
        var professional = await professionalRepository.GetByCpfToRegisterAsync(request.Cpf);
        if (professional is not null)
            return professional;

        using var scope = ApiTransactionScope.RepeatableRead(true);
        var (newProfessional, tempPassword) = await userService.CreateProfessionalUserAsync(
            new CreateProfessionalUserRequest
            (
                request.Email,
                request.Name,
                request.Cpf
            ));

        await professionalRepository.CreateAsync(newProfessional);

        if (tempPassword is not null)
        {
            try
            {
                await emailService.SendEmailAsync(
                    to: request.Email,
                    subject: PreRegisteredEmailTemplate.GetSubject(),
                    body: PreRegisteredEmailTemplate.GetBody(newProfessional.Cpf.GetFormattedValue(), tempPassword,
                        _frontendUrl),
                    isHtml: true
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha ao enviar email de pré-cadastro: {ex.Message}");
            }
        }

        scope.Complete();
        return newProfessional;
    }

    public async Task<ProfessionalResponse> RegisterProfessional(RegisterProfessionalRequest request)
    {
        using var scope = ApiTransactionScope.RepeatableRead(true);

        var professional = await ValidateAndGetProfessionalAsync(request);
        await ValidateProfessionDataAsync(request.ProfessionData);

        registerProfessional.Register(professional, request);

        await professionalRepository.UpdateAsync(professional);
        await professionalRepository.SaveChangesAsync();

        var specialtyDetail = new ProfessionalSpecialtyDetail(
            professional.Id,
            request.ProfessionData.ProfessionId,
            request.ProfessionData.SpecialityId,
            request.ProfessionData.SubSpecialityId == Guid.Empty ? null : request.ProfessionData.SubSpecialityId
        );
        await professionalRepository.CreateSpecialtyDetailAsync(specialtyDetail);

        var document = new ProfessionalDocument(
            professional.Id,
            request.DocumentData.DocumentType,
            request.DocumentData.DocumentNumber,
            request.DocumentData.DocumentState
        );
        await professionalRepository.CreateDocumentAsync(document);

        professional.SpecialtyDetails.Add(specialtyDetail);
        professional.Documents.Add(document);

        scope.Complete();
        return ProfessionalResponse.FromProfessional(professional);
    }

    private async Task<Professional> ValidateAndGetProfessionalAsync(RegisterProfessionalRequest request)
    {
        var professional = await professionalRepository.GetByCpfToRegisterAsync(request.Cpf);
        if (professional is null)
            throw new ProfessionalWithCpfNotFoundException(request.Cpf);
        if (request.ProfessionData is null)
            throw new ProfessionalWithCpfNotFoundException(request.Cpf);

        return professional;
    }

    private async Task ValidateProfessionDataAsync(ProfessionalProfessionRequest professionData)
    {
        var profession = await professionRepository.GetByIdAsync(professionData.ProfessionId);
        if (profession is null)
            throw new ProfessionNotFoundException(professionData.ProfessionId);

        var speciality = await professionRepository.GetSpecialityByIdAsync(professionData.SpecialityId);
        if (speciality is null)
            throw new SpecialityNotFoundException(professionData.SpecialityId);

        var subspeciality = await professionRepository.GetSubSpecialityByIdAsync(professionData.SubSpecialityId);
        if (subspeciality is null && professionData.SubSpecialityId.HasValue)
            throw new SubSpecialityNotFoundException(professionData.SubSpecialityId.Value);
    }

    public async Task<GetProfessionalResponse> GetProfessionalByUserId(Guid userId)
    {
        var professional = await professionalRepository.GetByUserIdWithDetailsAsync(userId)
                           ?? throw new ProfessionalNotFoundException(userId);

        return GetProfessionalResponse.FromProfessional(professional);
    }

    public async Task UpdateProfessional(UpdateProfessionalRequest request, Guid professionalId)
    {
        using var scope = ApiTransactionScope.RepeatableRead(true);

        var professional = await professionalRepository.GetByIdAsync(professionalId);
        if (professional is null)
            throw new ProfessionalNotFoundException(professionalId);
        
        var specialtyDetail = request.ProfessionData;
        await ValidateProfessionDataAsync(specialtyDetail);
        
        await UpdateSpecialityDetails(request, professional, specialtyDetail);
        
        await UpdateAddress(request, professional);

        professional.Update(
            request.Name,
            request.PreferredName,
            request.Email,
            request.Website,
            request.Instagram,
            request.Biography
        );

        await professionalRepository.UpdateAsync(professional, false);
        await professionalRepository.SaveChangesAsync();
      
        scope.Complete();
    }

    private async Task UpdateAddress(UpdateProfessionalRequest request, Professional professional)
    {
        var address = await addressRepository.GetByIdAsync(request.AddressId);
        if (address is null)
            throw new AddressNotFoundException(request.AddressId);
        var existingAddress = professional.Addresses.FirstOrDefault();
        if (existingAddress is not null)
        {
            existingAddress.Update(request.AddressId);
            await professionalRepository.UpdateProfessionalAddressAsync(existingAddress, false);
        }
        else
        {
            var newAddress = new ProfessionalAddress(professional.Id, request.AddressId);
            await professionalRepository.CreateProfessionalAddressAsync(newAddress, false);
        }
    }

    private async Task UpdateSpecialityDetails(UpdateProfessionalRequest request, Professional professional,
        ProfessionalProfessionRequest specialtyDetail)
    {
        var existingSpecialtyDetail = professional.GetSpecialityDetail(specialtyDetail.ProfessionId,
            specialtyDetail.SpecialityId,
            specialtyDetail.SubSpecialityId);

        if(existingSpecialtyDetail is not null)
        {
            existingSpecialtyDetail.Update(request.VideoPresentation);
            await professionalRepository.UpdateSpecialtyDetailsAsync(existingSpecialtyDetail, false);
        }
        else
        {
            var professionalSpecialtyDetail = new ProfessionalSpecialtyDetail(
                professional.Id,
                specialtyDetail.ProfessionId,
                specialtyDetail.SpecialityId,
                specialtyDetail.SubSpecialityId,
                request.VideoPresentation);
            await professionalRepository.CreateSpecialtyDetailAsync(professionalSpecialtyDetail, false);
        }
    }
}