using Application.DTOs.HealthCares.CreateHealthCareDTOs;

namespace Application.Services.HealthCares;
public interface IHealthCareService
{
    Task<CreateHealthCareResponse> CreateHealthCareAsync(CreateHealthCareRequest requestDto);
}