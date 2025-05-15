namespace Application.DTOs.HealthCares.CreateHealthCareDTOs;

public record CreateHealthCareRequest
{
    public required Guid OfficeId { get; init; }
    public required string Name { get; init; }
    public string? AnsNumber { get; init; }
    public string? Registry { get; init; }
    public required bool IsActive { get; init; }
}