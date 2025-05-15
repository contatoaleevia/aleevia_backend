namespace Application.DTOs.HealthCares.GetHealthCareDTOs;

public record GetHealthCareResponse
{
    public required GetHealthCareData HealthCare { get; init; }

    public static GetHealthCareResponse FromHealthCare(Domain.Entities.HealthCares.HealthCare healthCare)
    {
        ArgumentNullException.ThrowIfNull(healthCare);

        return new GetHealthCareResponse
        {
            HealthCare = new GetHealthCareData
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

public record GetHealthCareData
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