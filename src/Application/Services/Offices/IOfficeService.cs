using Application.DTOs.Offices.BindOfficeAddressDTOs;
using Application.DTOs.Offices.CreateOfficeDTOs;
using Application.DTOs.Offices.GetOfficeDTOs;
using Application.DTOs.Professionals;

namespace Application.Services.Offices;

public interface IOfficeService
{
    Task<Guid> CreateOffice(CreateOfficeRequest request, Guid userId);
    Task<Guid> BindOfficeAddress(BindOfficeAddressRequest request, Guid userId);
    Task DeleteOfficeAddress(Guid officeAddressId);
    Task<Guid> BindOfficeProfessional(BindOfficeProfessionalRequest request);
    Task<OfficeResponse> GetOffice(Guid id);
}