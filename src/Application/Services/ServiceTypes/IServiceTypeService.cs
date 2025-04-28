using Application.DTOs.ServiceTypes.CreateServiceTypeDTOs;
using Application.DTOs.ServiceTypes.DeactivateServiceTypeDTOs;
using Application.DTOs.ServiceTypes.GetServiceTypeDTOs;

namespace Application.Services.ServiceTypes;

public interface IServiceTypeService
{
    Task<CreateServiceTypeResponseDto> CreateAsync(CreateServiceTypeRequestDto requestDto);
    Task<List<GetServiceTypeResponseDto>> GetAllAsync();
    Task<DeactivateServiceTypeResponseDto> DeactivateAsync(DeactivateServiceTypeRequestDto requestDto);
} 