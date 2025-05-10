namespace Application.DTOs.Offices.CreateOfficeDTOs;

public record CreateOfficeResponse(Guid Id)
{
    public Guid Id { get; set; } = Id;
}