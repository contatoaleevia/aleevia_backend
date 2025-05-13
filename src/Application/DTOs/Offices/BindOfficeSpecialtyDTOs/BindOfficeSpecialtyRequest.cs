namespace Application.DTOs.Offices.BindOfficeSpecialtyDTOs;

public class BindOfficeSpecialtyRequest
{
    public required Guid OfficeId { get; set; }
    public required Guid SpecialtyId { get; set; }
} 