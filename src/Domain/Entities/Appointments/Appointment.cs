using CrossCutting.Entities;
using Domain.Entities.Associations;
using Domain.Entities.Identities;
using Domain.Entities.Offices;

namespace Domain.Entities.Appointments;
public class Appointment : AggregateRoot
{
    public Appointment(
        Guid patientId, 
        Guid professionalId,
        Guid officeId,
        AppointmentAddress? appointmentAddress,
        AppointmentType appointmentType, 
        decimal price, 
        DateTime date, 
        AppointmentStatus status, 
        Guid? patientCalendarEventId, 
        Guid? professionalCalendarEventId,
        DateTime? updatedAt, 
        DateTime? deletedAt)
    {
        PatientId = patientId;
        ProfessionalId = professionalId;
        OfficeId = officeId;
        AppointmentAddress = appointmentAddress;
        AppointmentType = appointmentType;
        Price = price;
        Date = date;
        Status = status;
        PatientCalendarEventId = patientCalendarEventId;
        ProfessionalCalendarEventId = professionalCalendarEventId;
        CreatedAt = DateTime.Now;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
    }

    public Appointment()
    {
    }

    public User Patient { get; private set; }
    public Guid PatientId { get; private set; }
    public User Professional { get; private set; }
    public Guid ProfessionalId { get; private set; }
    public Office Office { get; private set; }
    public Guid OfficeId { get; private set; }
    public AppointmentAddress? AppointmentAddress { get; private set; }
    public Guid? AppointmentAddressId { get; private set; }
    public AppointmentType AppointmentType { get; private set; }
    public decimal Price { get; private set; }
    public DateTime Date { get; private set; }
    public AppointmentStatus Status { get; private set; }
    public Guid? PatientCalendarEventId { get; private set; }
    public Guid? ProfessionalCalendarEventId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public void Delete()
    {
        DeletedAt = DateTime.Now;
    }
}