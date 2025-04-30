using CrossCutting.Extensions;

namespace Domain.Entities.Appointments;
public class AppointmentStatus
{
    public AppointmentStatusEnum AppointmentStatusEnum { get; set; }
    public string SourceTypeName => AppointmentStatusEnum.TryGetDescription();

    private AppointmentStatus()
    {
    }

    public AppointmentStatus(ushort sourceType)
    {
        AppointmentStatusEnum = (AppointmentStatusEnum)sourceType;
    }
}