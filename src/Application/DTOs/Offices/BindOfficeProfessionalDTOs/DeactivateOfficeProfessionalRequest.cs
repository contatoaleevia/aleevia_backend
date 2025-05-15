namespace Application.DTOs.Offices.BindOfficeProfessionalDTOs;

public record DeactivateOfficeProfessionalRequest
{
    public required Guid Id { get; init; }
} 