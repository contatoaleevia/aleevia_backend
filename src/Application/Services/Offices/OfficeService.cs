using System.Security.Cryptography.Xml;
using Application.DTOs.Offices.BindOfficeAddressDTOs;
using Application.DTOs.Offices.CreateOfficeDTOs;
using Application.DTOs.Professionals;
using Application.Services.Professionals;
using Domain.Contracts.Repositories;
using Domain.Entities.Offices;
using Domain.Entities.ValueObjects;
using Domain.Exceptions.Managers;
using Domain.Exceptions.Offices;
using Domain.Exceptions.Professionals;

namespace Application.Services.Offices;

public class OfficeService(
    IOfficeRepository repository,
    IManagerRepository managerRepository,
    IOfficeAddressRepository officeAddressRepository,
    IProfessionalService professionalService,
    IOfficesProfessionalsRepository officesProfessionalsRepository) : IOfficeService
{
    public async Task<Guid> CreateOffice(CreateOfficeRequest request, Guid userId)
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
            return response.Id;
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
        var cpf = Document.CreateDocumentAsCpf(request.Professional.Cpf);
        var preRegisterProfessional = new PreRegisterProfessionalRequest(cpf.Value, request.Professional.Email, request.Professional.Name);

        //TODO: Chamar Pre Cadastro
        var professional = await professionalService.PreRegisterWhenNotExists(preRegisterProfessional);

        var office = await repository.GetByIdAsync(request.OfficeId);
        if (office is null)
            throw new OfficeNotFoundException(request.OfficeId);

        var officeProfessional = await officesProfessionalsRepository.CreateAsync(new OfficesProfessionals(office.Id, professional.Id));

        return officeProfessional.Id;
    }
}