using Application.DTOs.Offices.BindOfficeAddressDTOs;
using Application.DTOs.Offices.CreateOfficeDTOs;

namespace Application.Services.Offices;

public interface IOfficeService
{
    Task<Guid> CreateOffice(CreateOfficeRequest request, Guid userId);
    Task<Guid> BindOfficeAddress(BindOfficeAddressRequest request, Guid userId);
    Task DeleteOfficeAddress(Guid officeAddressId);
}