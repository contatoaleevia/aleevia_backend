using Domain.Entities.ServiceProviders;

namespace Application.DTOs.ServiceProviders.GetServiceProviderDTOs;

public record GetServiceProviderResponseDto
{
    public required GetServiceProviderData ServiceProvider { get; init; }

    public static GetServiceProviderResponseDto FromServiceProvider(ServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        return new GetServiceProviderResponseDto
        {
            ServiceProvider = new GetServiceProviderData
            {
                Id = serviceProvider.Id,
                Cnpj = serviceProvider.Cnpj.Value,
                Name = serviceProvider.Name,
                CorporateName = serviceProvider.CorporateName,
                OfficeId = serviceProvider.OfficeId,
                IsActive = serviceProvider.IsActive,
                CreatedAt = serviceProvider.CreatedAt,
                UpdatedAt = serviceProvider.UpdatedAt
            }
        };
    }
}

public record GetServiceProviderData
{
    public required Guid Id { get; init; }
    public required string Cnpj { get; init; }
    public required string Name { get; init; }
    public required string CorporateName { get; init; }
    public required Guid OfficeId { get; init; }
    public required bool IsActive { get; init; }
    public required DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
} 