using CrossCutting.Entities;

namespace Domain.Entities.Associations;
public class AppointmentAddress : AggregateRoot
{
    public AppointmentAddress(
        Guid appointmentId,
        Guid addressId,
        DateTime createdAt,
        DateTime? updatedAt,
        DateTime? deletedAt)
    {
        AppointmentId = appointmentId;
        AddressId = addressId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
    }

    public Guid AppointmentId { get; private set; }
    public Guid AddressId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
}