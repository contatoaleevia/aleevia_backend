namespace Application.DTOs.Offices.BindOfficeSpecialtyDTOs;

public record DeactivateOfficeSpecialtyRequest
{
    public required Guid Id { get; init; }
} 