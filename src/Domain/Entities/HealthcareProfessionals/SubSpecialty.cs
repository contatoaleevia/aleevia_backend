using CrossCutting.Entities;

namespace Domain.Entities.HealthcareProfessionals;

public class SubSpecialty : Entity
{
    public string Name { get; private set; } = string.Empty;
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public Guid SpecialtyId { get; private set; }
    public Speciality Speciality { get; private set; } = null!;

    public SubSpecialty(string name, Guid specialtyId)
    {
        Name = name;
        SpecialtyId = specialtyId;
        Active = true;
        CreatedAt = DateTime.UtcNow;
    }

    protected SubSpecialty() { }
} 