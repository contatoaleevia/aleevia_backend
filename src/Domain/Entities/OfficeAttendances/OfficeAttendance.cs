using CrossCutting.Entities;
using Domain.Entities.Offices;
using Domain.Entities.ServiceTypes;
using Domain.Entities.ValueObjects;

namespace Domain.Entities.OfficeAttendances;

public class OfficeAttendance : AggregateRoot
{
    public Guid OfficeId { get; private set; }
    public Guid ServiceTypeId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public Money Price { get; private set; } = null!;
    public int Duration { get; private set; }
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
        decimal price,
        int duration,
        string? description)
    {
        OfficeId = officeId;
        ServiceTypeId = serviceTypeId;
        Title = title;
        Price = SetPrice(price);
        Duration = duration;
        Description = description;
        Active = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string title, decimal price, int duration, string? description)
    {
        Title = title;
        Price = SetPrice(price);
        Duration = duration;
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        Active = false;
        UpdatedAt = DateTime.UtcNow;
    }

    private static Money SetPrice(decimal price)
        => Money.Create(price);
} 