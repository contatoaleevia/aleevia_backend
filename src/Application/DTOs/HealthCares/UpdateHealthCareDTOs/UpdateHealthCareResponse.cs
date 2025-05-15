namespace Application.DTOs.HealthCares.UpdateHealthCareDTOs;

public record UpdateHealthCareResponse
{
    public required UpdateHealthCareData HealthCare { get; init; }

    public static UpdateHealthCareResponse FromHealthCare(Domain.Entities.HealthCares.HealthCare healthCare)
    {
        ArgumentNullException.ThrowIfNull(healthCare);

        return new UpdateHealthCareResponse
        {
            HealthCare = new UpdateHealthCareData
            {
                Id = healthCare.Id,
                OfficeId = healthCare.OfficeId,
                Name = healthCare.Name,
                AnsNumber = healthCare.AnsNumber,
                Registry = healthCare.Registry,
                IsActive = healthCare.IsActive,
                CreatedAt = healthCare.CreatedAt,
                UpdatedAt = healthCare.UpdatedAt
            }
        };
    }
}

public record UpdateHealthCareData
{
    public required Guid Id { get; init; }
    public required Guid OfficeId { get; init; }
    public required string Name { get; init; }
    public string? AnsNumber { get; init; }
    public string? Registry { get; init; }
    public required bool IsActive { get; init; }
    public required DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
} 