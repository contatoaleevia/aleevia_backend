using CrossCutting.Entities;
using Domain.Entities.Offices;
using Domain.Entities.ServiceTypes;

namespace Domain.Entities.OfficeAttendances;

public class OfficeAttendance : AggregateRoot
{
    public Guid OfficeId { get; private set; }
    public Guid ServiceTypeId { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public Office Office { get; set; } = null!;
    public ServiceType ServiceType { get; set; } = null!;

    private OfficeAttendance()
    {
    }

    public OfficeAttendance(Guid officeId, Guid serviceTypeId, string title, decimal price, string? description = null)
    {
        OfficeId = officeId;
        ServiceTypeId = serviceTypeId;
        Title = title;
        Description = description;
        Price = price;
        Active = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string title, decimal price, string? description = null)
    {
        Title = title;
        Description = description;
        Price = price;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        Active = false;
        UpdatedAt = DateTime.UtcNow;
    }
} 