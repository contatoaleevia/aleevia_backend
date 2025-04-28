using CrossCutting.Entities;

namespace Domain.Entities.ServiceTypes;

public class ServiceType : AggregateRoot
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }


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