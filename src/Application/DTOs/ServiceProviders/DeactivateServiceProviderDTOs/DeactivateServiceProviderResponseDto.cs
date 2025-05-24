using Domain.Entities.ServiceProviders;

namespace Application.DTOs.ServiceProviders.DeactivateServiceProviderDTOs;

public record DeactivateServiceProviderResponseDto
{
    public required DeactivateServiceProviderData ServiceProvider { get; init; }

    public static DeactivateServiceProviderResponseDto FromServiceProvider(ServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        return new DeactivateServiceProviderResponseDto
        {
            ServiceProvider = new DeactivateServiceProviderData
            {
                Id = serviceProvider.Id,
                IsActive = serviceProvider.IsActive,
                UpdatedAt = serviceProvider.UpdatedAt
            }
        };
    }
}

public record DeactivateServiceProviderData
{
    public required Guid Id { get; init; }
    public required bool IsActive { get; init; }
    public required DateTime? UpdatedAt { get; init; }
} 