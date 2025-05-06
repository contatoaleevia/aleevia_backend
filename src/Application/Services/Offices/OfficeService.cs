using Application.DTOs.Offices.BindOfficeAddressDTOs;
using Application.DTOs.Offices.CreateOfficeDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.Offices;
using Domain.Exceptions.Managers;
using Domain.Exceptions.Offices;

namespace Application.Services.Offices;

public class OfficeService(IOfficeRepository repository, IManagerRepository managerRepository, IOfficeAddressRepository officeAddressRepository) : IOfficeService
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
}