namespace Application.DTOs.OfficeAttendance.DeactivateOfficeAttendanceDTOs;

public class DeactivateOfficeAttendanceResponseDto
{
    public Guid Id { get; set; }
    public bool Active { get; set; }
    public DateTime? UpdatedAt { get; set; }
} 