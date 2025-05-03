using Application.DTOs.Appointments.CreateAppointmentDTOs;
using Application.DTOs.Appointments.DeleteAppointmentDTOs;

namespace Application.Services.Appointments;
public interface IAppointmentService
{
    Task<CreateAppointmentResponseDto> CreateAppointmentAsync(CreateAppointmentRequestDto requestDto);
    Task<DeleteAppointmentResponseDto> DeleteAppointmentAsync(Guid id);
}