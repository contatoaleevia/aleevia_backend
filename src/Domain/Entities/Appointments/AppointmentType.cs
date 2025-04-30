using CrossCutting.Extensions;

namespace Domain.Entities.Appointments;

public class AppointmentType
{
    public AppointmentTypeEnum AppointmentTypeEnum { get; set; }
    public string AppointmentTypeName => AppointmentTypeEnum.TryGetDescription();

    private AppointmentType()
    {
    }

    public AppointmentType(ushort appointmentType)
    {
        AppointmentTypeEnum = (AppointmentTypeEnum)appointmentType;
    }
}