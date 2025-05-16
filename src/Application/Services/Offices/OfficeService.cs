using Application.DTOs.Offices.BindOfficeAddressDTOs;
using Application.DTOs.Offices.BindOfficeProfessionalDTOs;
using Application.DTOs.Offices.BindOfficeSpecialtyDTOs;
using Application.DTOs.Offices.CreateOfficeDTOs;
using Application.DTOs.Offices.GetOfficeAnalyticsDTOs;
using Application.DTOs.Offices.GetOfficeDTOs;
using Application.DTOs.Offices.UpdateOfficeDTOs;
using Application.DTOs.Professionals;
using Application.Services.Professionals;
using CrossCutting.Extensions;
using Domain.Contracts.Repositories;
using Domain.Entities.Offices;
using Domain.Entities.ValueObjects;
using Domain.Exceptions.Managers;
using Domain.Exceptions.Offices;
using Domain.Exceptions.Professions;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Offices;

public class OfficeService(
    IOfficeRepository repository,
    IManagerRepository managerRepository,
    IOfficeAddressRepository officeAddressRepository,
    IProfessionalService professionalService,
    IOfficesProfessionalsRepository officesProfessionalsRepository,
    IOfficeSpecialtyRepository officeSpecialtyRepository,
    ISpecialtyRepository specialtyRepository,
    IOfficeFileSender fileSender,
    IFaqRepository faqRepository,
    IOfficeAttendanceRepository officeAttendanceRepository,
    IHealthCareRepository healthCareRepository) : IOfficeService
{
    public async Task<CreateOfficeResponse> CreateOffice(CreateOfficeRequest request, Guid userId)
    {
        var manager = await managerRepository.GetManagerByUserId(userId)
                      ?? throw new ManagerUserNotFoundException(userId);

        var logoId = Guid.NewGuid();
        var logoUrl = await UploadLogo(logoId, request.Logo);
        
        var office = new Office(
            owner: manager,
            name: request.Name,
            cnpj: request.Cnpj,
            phoneNumber: request.PhoneNumber,
            whatsapp: request.Whatsapp,
            email: request.Email,
            site: request.Site,
            instagram: request.Instagram,
            logo: FileS3.Create(logoId, logoUrl),
            individual: request.Individual
        );

        try
        {
            var response = await repository.CreateAsync(office);
            return new CreateOfficeResponse(response.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new CreateOfficeException(request.Name);
        }
    }

    public async Task<BindOfficeAddressResponse> BindOfficeAddress(BindOfficeAddressRequest request, Guid userId)
    {
        var manager = await managerRepository.GetManagerByUserId(userId)
                      ?? throw new ManagerUserNotFoundException(userId);

        var officeAddress = await officeAddressRepository.GetOfficeAddress(request.OfficeId);
        if (officeAddress.Count > 0) throw new OfficeAddressAlreadyExistsException(request.OfficeId);

        var newOfficeAddress = new OfficeAddress(
            addressId: request.AddressId,
            officeId: request.OfficeId,
            isTeleconsultation: request.AddressId == Guid.Empty
        );

        var response = await officeAddressRepository.CreateAsync(newOfficeAddress);
        return new BindOfficeAddressResponse(response.Id);
    }

    public async Task DeleteOfficeAddress(Guid officeAddressId)
    {
        var officeAddress = await officeAddressRepository.GetByIdAsync(officeAddressId)
                            ?? throw new OfficeAddressNotFoundException(officeAddressId);

        officeAddress.IsActive = false;

        await officeAddressRepository.UpdateAsync(officeAddress);
    }

    public async Task<BindOfficeProfessionalResponse> BindOfficeProfessional(BindOfficeProfessionalRequest request)
    {
        var professional = await professionalService.PreRegisterWhenNotExists(request.Professional);

        var office = await repository.GetByIdAsync(request.OfficeId);
        if(office is null) throw new OfficeNotFoundException(request.OfficeId);
        var officeProfessional = await officesProfessionalsRepository.GetByOfficeAndProfessional(request.OfficeId, professional.Id);
        
        if (officeProfessional is not null)
        {
            if (officeProfessional.IsActive)
                throw new OfficeProfessionalAlreadyExistsException(request.OfficeId, professional.Id);

            officeProfessional.Activate();
            await officesProfessionalsRepository.UpdateAsync(officeProfessional);
            return new BindOfficeProfessionalResponse(officeProfessional);
        }

        var newOfficeProfessional = new OfficesProfessional(
            request.OfficeId,
            professional.Id,
            request.Professional.Active,
            request.Professional.IsPublic
        );
        var response = await officesProfessionalsRepository.CreateAsync(newOfficeProfessional);
        return new BindOfficeProfessionalResponse(response);
    }

    public async Task DeactivateOfficeProfessional(DeactivateOfficeProfessionalRequest request)
    {
        var officeProfessional = await officesProfessionalsRepository.GetByIdAsync(request.Id)
            ?? throw new OfficeProfessionalNotFoundException(request.Id);

        officeProfessional.Deactivate();
        await officesProfessionalsRepository.UpdateAsync(officeProfessional);
    }

    public async Task<OfficeResponse> GetOfficeById(Guid id)
    {
        var office = await repository.GetByIdWithDetailsAsync(id) ?? throw new OfficeNotFoundException(id);
        
        return OfficeResponse.FromOffice(
            office,
            [.. office.Addresses], 
            [.. office.Professionals], 
            [.. office.Specialties],
            [.. office.HealthCares]
        );
    }

    public async Task<List<OfficeSimplifiedResponse>> GetOfficesByUserId(Guid userId)
    {
        var manager = await managerRepository.GetManagerByUserId(userId)
                      ?? throw new ManagerUserNotFoundException(userId);

        var offices = await repository.GetAllByOwnerIdWithDetailsAsync(manager.Id);
        return [.. offices.Select(office => 
            OfficeSimplifiedResponse.FromOffice(office, office.Addresses, office.Specialties)
        )];
    }

    public async Task<GetOfficeProfessionalsResponse> GetOfficeProfessionals(Guid officeId)
    {
        var office = await repository.GetByIdAsync(officeId) ?? throw new OfficeNotFoundException(officeId);
        var professionals = await officesProfessionalsRepository.GetByOfficeIdWithDetailsAsync(officeId);

        return GetOfficeProfessionalsResponse.FromOffice(office, professionals);
    }

    public async Task<BindOfficeSpecialtyResponse> BindOfficeSpecialty(BindOfficeSpecialtyRequest request)
    {
        var office = await repository.GetByIdAsync(request.OfficeId) ?? throw new OfficeNotFoundException(request.OfficeId);
        var specialty = await specialtyRepository.GetByIdAsync(request.SpecialtyId) ?? throw new SpecialtyNotFoundException(request.SpecialtyId);
        
        var officeSpecialty = await officeSpecialtyRepository.GetByOfficeAndSpecialty(request.OfficeId, request.SpecialtyId);
        Console.WriteLine(officeSpecialty);
        if (officeSpecialty != null)
        {
            if (officeSpecialty.IsActive)
                throw new OfficeSpecialtyAlreadyExistsException(request.OfficeId, request.SpecialtyId);

            officeSpecialty.Activate();
            await officeSpecialtyRepository.UpdateAsync(officeSpecialty);
            return new BindOfficeSpecialtyResponse(officeSpecialty.Id);
        }

        var newOfficeSpecialty = new OfficeSpecialty(
            request.OfficeId,
            request.SpecialtyId
        );
        var response = await officeSpecialtyRepository.CreateAsync(newOfficeSpecialty);
        return new BindOfficeSpecialtyResponse(response.Id);
    }

    public async Task DeactivateOfficeSpecialty(DeactivateOfficeSpecialtyRequest request)
    {
        var officeSpecialty = await officeSpecialtyRepository.GetByIdAsync(request.Id)
            ?? throw new OfficeSpecialtyNotFoundException(request.Id);

        officeSpecialty.Deactivate();
        await officeSpecialtyRepository.UpdateAsync(officeSpecialty);
    }
    
    private async Task<string?> UploadLogo(Guid id, IFormFile? formFile)
    {
        if (formFile == null)
            return null;
        using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);
        return await fileSender.UploadLogoAsync(id.ToString(), memoryStream);
    }

    public async Task<UpdateOfficeResponse> UpdateOffice(UpdateOfficeRequest request, Guid userId)
    {
        var manager = await managerRepository.GetManagerByUserId(userId)
                      ?? throw new ManagerUserNotFoundException(userId);

        var office = await repository.GetByIdAsync(request.Id)
                     ?? throw new OfficeNotFoundException(request.Id);

        if (office.OwnerId != manager.Id)
            throw new UnauthorizedOfficeAccessException(request.Id, userId);
       
        office.Update(
            name: request.Name,
            phoneNumber: request.PhoneNumber,
            whatsapp: request.Whatsapp,
            email: request.Email,
            site: request.Site,
            instagram: request.Instagram
        );

        if (request.Logo != null)
        {
            var logoUrl = office.GetLogoUrl();
        
            if (!logoUrl.IsNullOrEmpty())
                await fileSender.DeleteLogoAsync(office.GetLogoFileName()!);
          
            var logoId = office.GetLogoId() ?? Guid.NewGuid();
            logoUrl = await UploadLogo(logoId, request.Logo);
            office.SetLogo(FileS3.Create(logoId, logoUrl));
        }

        await repository.UpdateAsync(office);
        
        return UpdateOfficeResponse.FromOffice(office);
    }

    public async Task<GetOfficeAnalyticsResponse> GetOfficeAnalytics(Guid officeId, Guid userId)
    {
        var manager = await managerRepository.GetManagerByUserId(userId)
                      ?? throw new ManagerUserNotFoundException(userId);

        var office = await repository.GetByIdAsync(officeId)
                     ?? throw new OfficeNotFoundException(officeId);

        if (office.OwnerId != manager.Id)
            throw new UnauthorizedOfficeAccessException(officeId, userId);

        var totalProfessionals = await officesProfessionalsRepository.CountByOfficeIdAsync(officeId);
        var totalServices = await officeAttendanceRepository.CountByOfficeIdAsync(officeId);
        var totalFaqs = await faqRepository.CountBySourceIdAsync(officeId);
        var totalHealthCares = await healthCareRepository.CountByOfficeIdAsync(officeId);

        return GetOfficeAnalyticsResponse.FromOffice(
            office,
            totalProfessionals,
            totalServices,
            totalFaqs,
            totalHealthCares
        );
    }
}