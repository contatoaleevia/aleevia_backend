using System.Security.Cryptography.Xml;
using Application.DTOs.Offices.BindOfficeAddressDTOs;
using Application.DTOs.Offices.CreateOfficeDTOs;
using Application.DTOs.Offices.GetOfficeDTOs;
using Application.DTOs.Professionals;
using Application.Services.Professionals;
using Domain.Contracts.Repositories;
using Domain.Entities.Offices;
using Domain.Entities.ValueObjects;
using Domain.Exceptions.Managers;
using Domain.Exceptions.Offices;
using Domain.Exceptions.Professionals;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Offices;

public class OfficeService(
    IOfficeRepository repository,
    IManagerRepository managerRepository,
    IOfficeAddressRepository officeAddressRepository,
    IProfessionalService professionalService,
    IOfficesProfessionalsRepository officesProfessionalsRepository) : IOfficeService
{
    public async Task<CreateOfficeResponse> CreateOffice(CreateOfficeRequest request, Guid userId)
    {
        var manager = await managerRepository.GetManagerByUserId(userId)
                      ?? throw new ManagerUserNotFoundException(userId);

        var office = new Office(
            owner: manager,
            name: request.Name,
            cnpj: request.Cnpj,
            phoneNumber: request.PhoneNumber,
            whatsapp: request.Whatsapp,
            email: request.Email,
            site: request.Site,
            instagram: request.Instagram,
            logo: request.Logo
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

    public async Task<Guid> BindOfficeAddress(BindOfficeAddressRequest request, Guid userId)
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
        return response.Id;
    }

    public async Task DeleteOfficeAddress(Guid officeAddressId)
    {
        var officeAddress = await officeAddressRepository.GetByIdAsync(officeAddressId)
                            ?? throw new OfficeAddressNotFoundException(officeAddressId);

        officeAddress.IsActive = false;

        await officeAddressRepository.UpdateAsync(officeAddress);
    }

    public async Task<Guid> BindOfficeProfessional(BindOfficeProfessionalRequest request)
    {
        var professional = await professionalService.PreRegisterWhenNotExists(request.Professional);

        var office = await repository.GetByIdAsync(request.OfficeId);
        if (office is null)
            throw new OfficeNotFoundException(request.OfficeId);

        var officeProfessional = new OfficesProfessional(
            request.OfficeId,
            professional.Id,
            request.Professional.Active,
            request.Professional.IsPublic
        );
        await officesProfessionalsRepository.CreateAsync(officeProfessional);

        return officeProfessional.Id;
    }

    public async Task<OfficeResponse> GetOffice(Guid id)
    {
        var office = await repository.GetByIdAsync(id) ?? throw new OfficeNotFoundException(id);
        var addresses = await officeAddressRepository.GetOfficeAddress(id);

        return OfficeResponse.FromOffice(office, addresses);
    }
}