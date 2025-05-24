using Application.DTOs.ServiceProviders.CreateServiceProviderDTOs;
using Application.DTOs.ServiceProviders.GetServiceProviderDTOs;
using Application.DTOs.ServiceProviders.DeactivateServiceProviderDTOs;
using Application.DTOs.ServiceProviders.UpdateServiceProviderDTOs;

namespace Application.Services.ServiceProviders;

public interface IServiceProviderService
{
    Task<CreateServiceProviderResponseDto> CreateAsync(CreateServiceProviderRequestDto requestDto);
    Task<List<GetServiceProviderResponseDto>> SearchAsync(GetServiceProviderByFilterRequestDto filter);
    Task<List<GetServiceProviderResponseDto>> GetAllAsync(Guid officeId);
    Task<UpdateServiceProviderResponseDto> UpdateAsync(UpdateServiceProviderRequestDto requestDto);
    Task<DeactivateServiceProviderResponseDto> DeactivateAsync(DeactivateServiceProviderRequestDto requestDto);
} 