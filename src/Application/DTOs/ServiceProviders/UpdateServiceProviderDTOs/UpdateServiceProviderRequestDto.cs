namespace Application.DTOs.ServiceProviders.UpdateServiceProviderDTOs;

public record UpdateServiceProviderRequestDto
{
    public required Guid Id { get; init; }
    public string? Name { get; init; }
    public string? CorporateName { get; init; }
} 