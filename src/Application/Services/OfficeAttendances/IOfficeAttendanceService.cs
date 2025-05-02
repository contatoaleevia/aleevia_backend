using Application.DTOs.OfficeAttendance.CreateOfficeAttendanceDTOs;
using Application.DTOs.OfficeAttendance.DeactivateOfficeAttendanceDTOs;
using Application.DTOs.OfficeAttendance.GetOfficeAttendanceDTOs;

namespace Application.Services.OfficeAttendances;

public interface IOfficeAttendanceService
{
    Task<CreateOfficeAttendanceResponseDto> CreateAsync(CreateOfficeAttendanceRequestDto requestDto);
    Task<List<GetOfficeAttendanceResponseDto>> GetAllByOfficeIdAsync(Guid officeId);
    Task<DeactivateOfficeAttendanceResponseDto> DeactivateAsync(DeactivateOfficeAttendanceRequestDto requestDto);
} 