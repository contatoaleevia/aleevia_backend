using CrossCutting.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entities.HealthcareProfessionals;

public class Specialty : Entity
{
    public string Name { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public Guid ProfessionId { get; private set; }
    public virtual Profession Profession { get; private set; }
    public virtual ICollection<SubSpecialty> SubSpecialties { get; private set; } = [];

    public Specialty(string name, Guid professionId)
    {
        Name = name;
        ProfessionId = professionId;
        Active = true;
        CreatedAt = DateTime.UtcNow;
        SubSpecialties = [];
    }

    protected Specialty() { }

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