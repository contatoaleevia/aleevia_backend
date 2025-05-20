using CrossCutting.Entities;
using Domain.Entities.Offices;

namespace Domain.Entities.HealthCares;
public class HealthCare : AggregateRoot
{
    public Office Office { get; private set; } = null!;
    public Guid OfficeId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? AnsNumber { get; private set; }
    public string? Registry { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public HealthCare(Guid officeId, string name, string? ansNumber, string? registry, bool isActive)
    {
        OfficeId = officeId;
        Name = name;
        AnsNumber = ansNumber;
        Registry = registry;
        IsActive = isActive;
        CreatedAt = DateTime.UtcNow;
    }

    protected HealthCare() { }

    public void Update(string? name, string? ansNumber, string? registry, bool? isActive)
    {
        Name = name ?? Name;
        AnsNumber = ansNumber ?? AnsNumber;
        Registry = registry ?? Registry;
        IsActive = isActive ?? IsActive;
        UpdatedAt = DateTime.UtcNow;
    }
    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }
    public void Activate()
    {
        IsActive = true;
        UpdatedAt = DateTime.UtcNow;
    }
}