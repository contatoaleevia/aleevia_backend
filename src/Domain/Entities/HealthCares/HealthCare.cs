using CrossCutting.Entities;
using Domain.Entities.Offices;

namespace Domain.Entities.HealthCares;
public class HealthCare : AggregateRoot
{
    public Office Office { get; private set; } = null!;
    public Guid OfficeId { get; private set; }
    public string Name { get; private set; }
    public string? AnsNumber { get; private set; }
    public string? Registration { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public HealthCare(Guid officeId, string name, string? ansNumber, string? registration, bool active)
    {
        OfficeId = officeId;
        Name = name;
        AnsNumber = ansNumber;
        Registration = registration;
        Active = active;
        CreatedAt = DateTime.UtcNow;
    }

    protected HealthCare() { }

    public void Update(string name)
    {
        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }
    public void Deactivate()
    {
        Active = false;
        UpdatedAt = DateTime.UtcNow;
    }
    public void Activate()
    {
        Active = true;
        UpdatedAt = DateTime.UtcNow;
    }
}