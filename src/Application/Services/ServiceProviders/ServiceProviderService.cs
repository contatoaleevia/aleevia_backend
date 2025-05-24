using Application.DTOs.ServiceProviders.CreateServiceProviderDTOs;
using Application.DTOs.ServiceProviders.GetServiceProviderDTOs;
using Application.DTOs.ServiceProviders.DeactivateServiceProviderDTOs;
using Application.DTOs.ServiceProviders.UpdateServiceProviderDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.ServiceProviders;
using Domain.Exceptions.ServiceProvider;
using Domain.Exceptions.Offices;

namespace Application.Services.ServiceProviders;

public class ServiceProviderService(
    IServiceProviderRepository repository,
    IOfficeRepository officeRepository
) : IServiceProviderService
{
    public async Task<CreateServiceProviderResponseDto> CreateAsync(CreateServiceProviderRequestDto requestDto)
    {
        _ = await officeRepository.GetByIdAsync(requestDto.OfficeId)
            ?? throw new OfficeNotFoundException(requestDto.OfficeId);

        var existingProviders = await repository.SearchAsync(requestDto.OfficeId, requestDto.Cnpj);
        if (existingProviders.Count != 0)
            throw new ServiceProviderAlreadyExistsException(requestDto.Cnpj);

        var serviceProvider = new ServiceProvider(
            cnpj: requestDto.Cnpj,
            name: requestDto.Name,
            corporateName: requestDto.CorporateName,
            officeId: requestDto.OfficeId
        );

        await repository.CreateAsync(serviceProvider);

        return CreateServiceProviderResponseDto.FromServiceProvider(serviceProvider);
    }

    public async Task<List<GetServiceProviderResponseDto>> SearchAsync(GetServiceProviderByFilterRequestDto filter)
    {
        var serviceProviders = await repository.SearchAsync(filter.OfficeId, filter.Cnpj, filter.Name);
        
        return [.. serviceProviders.Select(GetServiceProviderResponseDto.FromServiceProvider)];
    }

    public async Task<List<GetServiceProviderResponseDto>> GetAllAsync(Guid officeId)
    {
        _ = await officeRepository.GetByIdAsync(officeId)
            ?? throw new OfficeNotFoundException(officeId);
            
        var serviceProviders = await repository.GetAllAsync(officeId);
        
        return [.. serviceProviders.Select(GetServiceProviderResponseDto.FromServiceProvider)];
    }

    public async Task<UpdateServiceProviderResponseDto> UpdateAsync(UpdateServiceProviderRequestDto requestDto)
    {
        var serviceProvider = await repository.GetByIdAsync(requestDto.Id)
            ?? throw new ServiceProviderNotFoundException(requestDto.Id);

        serviceProvider.Update(
            name: requestDto.Name,
            corporateName: requestDto.CorporateName
        );

        await repository.UpdateAsync(serviceProvider);

        return UpdateServiceProviderResponseDto.FromServiceProvider(serviceProvider);
    }

    public async Task<DeactivateServiceProviderResponseDto> DeactivateAsync(DeactivateServiceProviderRequestDto requestDto)
    {
        var serviceProvider = await repository.GetByIdAsync(requestDto.Id)
            ?? throw new ServiceProviderNotFoundException(requestDto.Id);

        serviceProvider.Deactivate();
        await repository.UpdateAsync(serviceProvider);

        return DeactivateServiceProviderResponseDto.FromServiceProvider(serviceProvider);
    }
} 