using Domain.Entities.Appointments;
using Domain.Entities.Associations;
using Domain.Entities.Identities;
using Domain.Entities.Offices;

namespace Application.DTOs.Appointments.CreateAppointmentDTOs;
public class CreateAppointmentResponseDto
{
    public CreateAppointmentResponseDto(
        User patient, 
        User professional, 
        Office office, 
        AppointmentAddress? appointmentAddress, 
        AppointmentType appointmentType, 
        decimal price, DateTime date, 
        AppointmentStatus status, 
        Guid? patientCalendarEventId, 
        Guid? professionalCalendarEventId, 
        DateTime createdAt, 
        DateTime? updatedAt, 
        DateTime? deletedAt)
    {
        Patient = patient;
        Professional = professional;
        Office = office;
        AppointmentAddress = appointmentAddress;
        AppointmentType = appointmentType;
        Price = price;
        Date = date;
        Status = status;
        PatientCalendarEventId = patientCalendarEventId;
        ProfessionalCalendarEventId = professionalCalendarEventId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
    }

    public User Patient { get; private set; }
    public User Professional { get; private set; }
    public Office Office { get; private set; }
    public AppointmentAddress? AppointmentAddress { get; private set; }
    public AppointmentType AppointmentType { get; private set; }
    public decimal Price { get; private set; }
    public DateTime Date { get; private set; }
    public AppointmentStatus Status { get; private set; }
    public Guid? PatientCalendarEventId { get; private set; }
    public Guid? ProfessionalCalendarEventId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
}