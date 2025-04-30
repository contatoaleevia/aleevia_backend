namespace Application.DTOs.Appointments.DeleteAppointmentDTOs;
public class DeleteAppointmentResponseDto(Guid guid)
{
    public Guid Guid { get; private set; } = guid;
}