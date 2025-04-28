using Application.DTOs.Offices.CreateOfficeDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.Offices;
using Domain.Exceptions.Offices;

namespace Application.Services.Offices;

public class OfficeService(IOfficeRepository repository) : IOfficeService
{
    public async Task<Guid> CreateOffice(CreateOfficeRequest request, Guid ownerId)
    {
        var office = new Office(
            ownerId: ownerId,
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
}