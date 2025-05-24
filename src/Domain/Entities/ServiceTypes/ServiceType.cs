using CrossCutting.Entities;
using JetBrains.Annotations;

namespace Domain.Entities.ServiceTypes;

public class ServiceType : AggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }


    [UsedImplicitly]
    private ServiceType()
    {
    }

    public ServiceType(string name, string? description = null)
    {
        Name = name;
        Description = description;
        Active = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        Active = false;
        UpdatedAt = DateTime.UtcNow;
    }
} 