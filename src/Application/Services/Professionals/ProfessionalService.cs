using Application.DTOs.Email;
using Application.DTOs.Professionals;
using Application.Helpers;
using CrossCutting.Databases;
using Domain.Contracts.Repositories;
using Domain.Entities.Identities;
using Domain.Entities.Offices;
using Domain.Entities.Professionals;
using Domain.Entities.ValueObjects;
using Domain.Exceptions;
using Domain.Exceptions.Offices;
using Domain.Exceptions.Professionals;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Professionals;
public class ProfessionalService(
    IOfficesProfessionalsRepository officesProfessionalsRepository,
    IProfessionalRepository professionalRepository, 
    UserManager<User> userManager,
    IOfficeRepository officeRepository,
    IEmailService emailService) 
    : IProfessionalService
{
    public async Task<Guid> PreCreateProfessional(PreCreateProfessionalRequestDto requestDto)
    {
        var professional = await professionalRepository.GetByCpfAsync(Document.CreateDocumentAsCpf(requestDto.Cpf));
        if (professional is not null)
            throw new ProfessionalAlreadyExistsException(requestDto.Cpf);

        var newUser = new User(
            email: requestDto.Email,
            phoneNumber: string.Empty,
            name: requestDto.Nome,
            cpf: requestDto.Cpf,
            cnpj: null,
            userType: UserType.HealthcareProfessional);

        var tempPassword = RandomGenerator.Generate(lenght: 10);

        await userManager.CreateAsync(newUser, tempPassword);

        var newProfessional = new Professional(
            user: newUser,
            userId: newUser.Id,
            status: new ProfessionalStatusType(0),
            officeId: requestDto.OfficeId,
            active: false,
            cpf: Document.CreateDocumentAsCnpj(requestDto.Cpf),
            createdAt: DateTime.UtcNow);


        using (var scope = ApiTransactionScope.RepeatableRead(true))
        {
            var response = await professionalRepository.CreateAsync(newProfessional);

            try
            {
                await emailService.SendEmailAsync(
                    to: newUser.Email!,
                    subject: PreRegisteredEmailTemplate.GetSubject(),
                    body: PreRegisteredEmailTemplate.GetBody(newUser.Cpf.Value, tempPassword, requestDto.Link),
                    isHtml: true
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha ao enviar email de pré-cadastro: {ex.Message}");
            }
            scope.Complete();
            return response.Id;
        }
    }

    public async Task<Guid> CreateProfessional(CreateProfessionalRequestDto requestDto)
    {
        var user = await userManager.FindByIdAsync(requestDto.UserId.ToString());
        if (user is null)
            throw new UserNotFoundException(requestDto.UserId);

        var professional = new Professional(
            user: user,
            userId: user.Id,
            status: new ProfessionalStatusType(requestDto.Status),
            officeId: requestDto.OfficeId,
            active: requestDto.Active,
            cpf: Document.CreateDocumentAsCnpj(requestDto.Cnpj),
            createdAt: DateTime.UtcNow
        );

        try
        {
            var response = await professionalRepository.CreateAsync(professional);
            return response.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new CreateProfessionalException(user.Id);
        }
    }

    public async Task<Guid> BindProfessionalOffice(BindProfessionalOfficeRequestDto requestDto)
    {
        // Caso o profissional não exista, criar um pré-registro do profissional 
        var cpf = Document.CreateDocumentAsCpf(requestDto.Cpf);
        var user = await professionalRepository.GetByCpfAsync(cpf);
        if (user is null)
            throw new ProfessionalUserNotFoundException(requestDto.Cpf);

        var professional = await professionalRepository.GetByIdAsync(user.Id);
        if (professional is null)
            throw new ProfessionalNotFoundException(user.Id);

        var office = await officeRepository.GetByIdAsync(requestDto.OfficeId);
        if (office is null)
            throw new OfficeNotFoundException(requestDto.OfficeId);

        var officeProfessional = await officesProfessionalsRepository.CreateAsync(new OfficesProfessionals(office.Id, professional.Id));

        return officeProfessional.Id;
    }
}