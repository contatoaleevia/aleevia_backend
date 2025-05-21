using Application.DTOs.HealthCares.CreateHealthCareDTOs;
using Application.DTOs.HealthCares.GetHealthCareDTOs;
using Application.DTOs.HealthCares.UpdateHealthCareDTOs;

namespace Application.Services.HealthCares;
public interface IHealthCareService
{
    Task<CreateHealthCareResponse> CreateHealthCareAsync(CreateHealthCareRequest requestDto);
    Task<List<GetHealthCareResponse>> GetHealthCaresByOfficeIdAsync(Guid officeId);
    Task<UpdateHealthCareResponse> UpdateHealthCareAsync(UpdateHealthCareRequest requestDto);
    Task DeleteHealthCareAsync(Guid id);
}