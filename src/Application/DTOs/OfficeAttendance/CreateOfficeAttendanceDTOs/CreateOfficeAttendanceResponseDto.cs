namespace Application.DTOs.OfficeAttendance.CreateOfficeAttendanceDTOs;

public class CreateOfficeAttendanceResponseDto
{
    public Guid Id { get; set; }
    public Guid OfficeId { get; set; }
    public Guid ServiceTypeId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
} 