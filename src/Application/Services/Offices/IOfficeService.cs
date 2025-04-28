using Application.DTOs.Offices.CreateOfficeDTOs;

namespace Application.Services.Offices;

public interface IOfficeService
{
    Task<Guid> CreateOffice(CreateOfficeRequest request, Guid userId);
}