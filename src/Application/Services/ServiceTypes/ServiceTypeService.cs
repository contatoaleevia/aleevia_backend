using Application.DTOs.ServiceTypes.CreateServiceTypeDTOs;
using Application.DTOs.ServiceTypes.DeactivateServiceTypeDTOs;
using Application.DTOs.ServiceTypes.GetServiceTypeDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.ServiceTypes;

namespace Application.Services.ServiceTypes;

public class ServiceTypeService(
    IServiceTypeRepository repository
) : IServiceTypeService
{

    public async Task<List<GetServiceTypeResponseDto>> GetAllAsync()
    {
        var serviceTypes = await repository.GetAllAsync();
        return [.. serviceTypes.Select(st => new GetServiceTypeResponseDto
        {
            Id = st.Id,
            Name = st.Name,
            Description = st.Description,
            IsActive = st.IsActive,
            CreatedAt = st.CreatedAt,
            UpdatedAt = st.UpdatedAt
        })];
    }
    public async Task<CreateServiceTypeResponseDto> CreateAsync(CreateServiceTypeRequestDto requestDto)
    {
        var serviceType = new ServiceType(
            name: requestDto.Name,
            description: requestDto.Description
        );

        await repository.CreateAsync(serviceType);

        return new CreateServiceTypeResponseDto
        {
            Id = serviceType.Id,
            Name = serviceType.Name,
            Description = serviceType.Description,
            IsActive = serviceType.IsActive,
            CreatedAt = serviceType.CreatedAt
        };
    }

    public async Task<DeactivateServiceTypeResponseDto> DeactivateAsync(DeactivateServiceTypeRequestDto requestDto)
    {
        var serviceType = await repository.GetByIdAsync(requestDto.Id);
        
        if (serviceType is null)
            throw new KeyNotFoundException($"Tipo de serviço com ID {requestDto.Id} não encontrado");

        serviceType.Deactivate();
        await repository.UpdateAsync(serviceType);

        return new DeactivateServiceTypeResponseDto
        {
            Id = serviceType.Id,
            IsActive = serviceType.IsActive,
            UpdatedAt = serviceType.UpdatedAt
        };
    }
} 