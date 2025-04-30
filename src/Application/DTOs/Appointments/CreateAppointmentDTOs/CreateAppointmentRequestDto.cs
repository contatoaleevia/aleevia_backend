using Domain.Entities.Appointments;
using Domain.Entities.Associations;

namespace Application.DTOs.Appointments.CreateAppointmentDTOs;
public class CreateAppointmentRequestDto
{
    public CreateAppointmentRequestDto(
        Guid patientId, 
        Guid professionalId, 
        Guid officeId, 
        AppointmentAddress? appointmentAddress, 
        AppointmentType appointmentType, 
        decimal price, 
        DateTime date, 
        AppointmentStatus status)
    {
        PatientId = patientId;
        ProfessionalId = professionalId;
        OfficeId = officeId;
        AppointmentAddress = appointmentAddress;
        AppointmentType = appointmentType;
        Price = price;
        Date = date;
        Status = status;
    }

    public Guid PatientId { get; private set; }
    public Guid ProfessionalId { get; private set; }
    public Guid OfficeId { get; private set; }
    public AppointmentAddress? AppointmentAddress { get; private set; }
    public AppointmentType AppointmentType { get; private set; }
    public decimal Price { get; private set; }
    public DateTime Date { get; private set; }
    public AppointmentStatus Status { get; private set; }
}