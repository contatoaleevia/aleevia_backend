using System.ComponentModel;

namespace Domain.Entities.Appointments;
public enum AppointmentTypeEnum : ushort
{
    [Description("Teleconsulta")]
    Teleconsultation = 0,
    [Description("Presencial")]
    Presential = 1
}