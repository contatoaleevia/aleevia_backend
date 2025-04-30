using Application.DTOs.Appointments.CreateAppointmentDTOs;
using Application.DTOs.Appointments.DeleteAppointmentDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.Appointments;
using Domain.Exceptions.Appointments;

namespace Application.Services.Appointments;
public class AppointmentService(IAppointmentRepository repository) : IAppointmentService
{
    public async Task<CreateAppointmentResponseDto> CreateAppointmentAsync(CreateAppointmentRequestDto requestDto)
    {
        var appointment = new Appointment(
            patientId: requestDto.PatientId,
            professionalId: requestDto.ProfessionalId,
            officeId: requestDto.OfficeId,
            appointmentAddress: requestDto.AppointmentAddress,
            appointmentType: requestDto.AppointmentType,
            price: requestDto.Price,
            date: requestDto.Date,
            status: requestDto.Status,
            patientCalendarEventId: null,
            professionalCalendarEventId: null,
            updatedAt: null,
            deletedAt: null);

        if (appointment.AppointmentType.AppointmentTypeEnum != AppointmentTypeEnum.Teleconsultation)
        {
            var enderecoEmUso = await repository.GetAppointmentByAddress(appointment.AppointmentAddressId, appointment.Date);

            if (enderecoEmUso != null)
                throw new AppointmentAddressUnavailableException(appointment.AppointmentAddressId);
        }

        var result = await repository.CreateAsync(appointment);

        return new CreateAppointmentResponseDto(
            patient: result.Patient,
            professional: result.Professional,
            office: result.Office,
            appointmentAddress: result.AppointmentAddress,
            appointmentType: result.AppointmentType,
            price: result.Price,
            date: result.Date,
            status: result.Status,
            patientCalendarEventId: result.PatientCalendarEventId,
            professionalCalendarEventId: result.ProfessionalCalendarEventId,
            createdAt: result.CreatedAt,
            updatedAt: result.UpdatedAt,
            deletedAt: result.DeletedAt);
    }

    public async Task<DeleteAppointmentResponseDto> DeleteAppointmentAsync(Guid id)
    {
        var appointment = await repository.GetByIdAsync(id);
        if (appointment == null)
            throw new AppointmentNotFoundException(id);

        appointment.Delete();

        await repository.UpdateAsync(appointment);

        return new DeleteAppointmentResponseDto(
            guid: appointment.Id);
    }
}