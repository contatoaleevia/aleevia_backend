using CrossCutting.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entities.HealthcareProfessionals;

public class Profession : AggregateRoot
{
    public string Name { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public virtual ICollection<Specialty> Specialties { get; private set; }

    public Profession(string name)
    {
        Name = name;
        Active = true;
        CreatedAt = DateTime.UtcNow;
        Specialties = new List<Specialty>();
    }

    protected Profession() { }

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