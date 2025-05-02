using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.OfficeAttendance.DeactivateOfficeAttendanceDTOs;

public class DeactivateOfficeAttendanceRequestDto
{
    [Required(ErrorMessage = "ID é obrigatório")]
    public Guid Id { get; set; }
} 