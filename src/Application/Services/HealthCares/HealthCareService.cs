using Application.DTOs.HealthCares.CreateHealthCareDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.HealthCares;

namespace Application.Services.HealthCares;
public class HealthCareService(IHealthCareRepository healthCareRepository) : IHealthCareService
{
    public async Task<CreateHealthCareResponse> CreateHealthCareAsync(CreateHealthCareRequest requestDto)
    {
        var newHealthCare = new HealthCare(
            officeId: requestDto.OfficeId,
            name: requestDto.Name,
            ansNumber: requestDto.AnsNumber,
            registration: requestDto.Registration,
            active: requestDto.Active
            );

        var healthCare = await healthCareRepository.CreateAsync(newHealthCare);

        return new CreateHealthCareResponse() { Id = healthCare.Id };
    }
}