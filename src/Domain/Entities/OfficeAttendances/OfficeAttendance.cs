using CrossCutting.Entities;
using Domain.Entities.Offices;
using Domain.Entities.ServiceTypes;
using Domain.Entities.ValueObjects;

namespace Domain.Entities.OfficeAttendances;

public class OfficeAttendance : AggregateRoot
{
    public Guid OfficeId { get; private set; }
    public Guid ServiceTypeId { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public Money Price { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public Office Office { get; set; } = null!;
    public ServiceType ServiceType { get; set; } = null!;

    private OfficeAttendance()
    {
    }

    public OfficeAttendance(
        Guid officeId,
        Guid serviceTypeId,
        string title,
        long price,
        string? description)
    {
        OfficeId = officeId;
        ServiceTypeId = serviceTypeId;
        Title = title;
        Price = SetPrice(price);
        Description = description;
        Active = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string title, long price, string? description)
    {
        Title = title;
        Price = SetPrice(price);
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        Active = false;
        UpdatedAt = DateTime.UtcNow;
    }

    private static Money SetPrice(long? price)
        => price is null ? Money.CreateAsEmpty() : Money.Create(price.Value);
} 