using CrossCutting.Entities;
using System;

namespace Domain.Entities.HealthcareProfessionals;

public class SubSpecialty : Entity
{
    public string Name { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public Guid SpecialtyId { get; private set; }
    public Specialty Specialty { get; private set; }

    public SubSpecialty(string name, Guid specialtyId)
    {
        Name = name;
        SpecialtyId = specialtyId;
        Active = true;
        CreatedAt = DateTime.UtcNow;
    }

    protected SubSpecialty() { }

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