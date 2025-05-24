using Domain.Entities.ServiceProviders;

namespace Application.DTOs.ServiceProviders.CreateServiceProviderDTOs;

public record CreateServiceProviderResponseDto
{
    public required CreateServiceProviderData ServiceProvider { get; init; }

    public static CreateServiceProviderResponseDto FromServiceProvider(ServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        return new CreateServiceProviderResponseDto
        {
            ServiceProvider = new CreateServiceProviderData
            {
                Id = serviceProvider.Id,
                Cnpj = serviceProvider.Cnpj.GetFormattedValue(),
                Name = serviceProvider.Name,
                CorporateName = serviceProvider.CorporateName,
                OfficeId = serviceProvider.OfficeId,
                IsActive = serviceProvider.IsActive,
                CreatedAt = serviceProvider.CreatedAt
            }
        };
    }
}

public record CreateServiceProviderData
{
    public required Guid Id { get; init; }
    public required string Cnpj { get; init; }
    public required string Name { get; init; }
    public required string CorporateName { get; init; }
    public required Guid OfficeId { get; init; }
    public required bool IsActive { get; init; }
    public required DateTime CreatedAt { get; init; }
} 