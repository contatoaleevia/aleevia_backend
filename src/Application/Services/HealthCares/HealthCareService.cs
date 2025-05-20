using Application.DTOs.HealthCares.CreateHealthCareDTOs;
using Application.DTOs.HealthCares.GetHealthCareDTOs;
using Application.DTOs.HealthCares.UpdateHealthCareDTOs;
using Domain.Contracts.Repositories;
using Domain.Exceptions.HealthCare;
using Domain.Exceptions.Offices;
using Domain.Entities.HealthCares;

namespace Application.Services.HealthCares;
public class HealthCareService(
    IHealthCareRepository healthCareRepository,
    IOfficeRepository officeRepository) : IHealthCareService
{
    public async Task<CreateHealthCareResponse> CreateHealthCareAsync(CreateHealthCareRequest requestDto)
    {
        _ = await officeRepository.GetByIdAsync(requestDto.OfficeId) ?? throw new OfficeNotFoundException(requestDto.OfficeId);

        var newHealthCare = new HealthCare(
            officeId: requestDto.OfficeId,
            name: requestDto.Name,
            ansNumber: requestDto.AnsNumber,
            registry: requestDto.Registry,
            isActive: requestDto.IsActive
        );

        var healthCare = await healthCareRepository.CreateAsync(newHealthCare);

        return CreateHealthCareResponse.FromHealthCare(healthCare);
    }

    public async Task<List<GetHealthCareResponse>> GetHealthCaresByOfficeIdAsync(Guid officeId)
    {
        var office = await officeRepository.GetByIdAsync(officeId) ?? throw new OfficeNotFoundException(officeId);

        var healthCares = await healthCareRepository.GetByOfficeIdAsync(officeId);
        return [.. healthCares.Select(GetHealthCareResponse.FromHealthCare)];
    }

    public async Task<UpdateHealthCareResponse> UpdateHealthCareAsync(UpdateHealthCareRequest requestDto)
    {
        var healthCare = await healthCareRepository.GetByIdAsync(requestDto.Id) ?? throw new HealthCareNotFoundException(requestDto.Id);

        healthCare.Update(
            name: requestDto.Name,
            ansNumber: requestDto.AnsNumber,
            registry: requestDto.Registry,
            isActive: requestDto.IsActive
        );

        await healthCareRepository.UpdateAsync(healthCare);

        return UpdateHealthCareResponse.FromHealthCare(healthCare);
    }

    public async Task DeleteHealthCareAsync(Guid id)
    {
        var healthCare = await healthCareRepository.GetByIdAsync(id) 
                            ?? throw new HealthCareNotFoundException(id);

        healthCare.Deactivate();
        await healthCareRepository.UpdateAsync(healthCare);
    }
}