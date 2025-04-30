namespace Application.DTOs.OfficeAttendance.GetOfficeAttendanceDTOs;

public class GetOfficeAttendanceResponseDto
{
    public Guid Id { get; set; }
    public Guid OfficeId { get; set; }
    public Guid ServiceTypeId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public string ServiceTypeName { get; set; } = null!;
    public string? ServiceTypeDescription { get; set; }
} 