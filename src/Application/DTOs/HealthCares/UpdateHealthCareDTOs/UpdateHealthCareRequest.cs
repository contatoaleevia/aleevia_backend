namespace Application.DTOs.HealthCares.UpdateHealthCareDTOs;

public record UpdateHealthCareRequest
{
    public required Guid Id { get; init; }
    public string? Name { get; init; }
    public string? AnsNumber { get; init; }
    public string? Registry { get; init; }
    public bool? IsActive { get; init; }
} 