using System.ComponentModel;

namespace Domain.Entities.Appointments;
public enum AppointmentStatusEnum : ushort
{
    [Description("Pendente")]
    Pending = 0,
    [Description("Confirmado")]
    Confirmed = 1,
    [Description("Cancelado")]
    Canceled = 2,
    [Description("Finalizado")]
    Completed = 3
}