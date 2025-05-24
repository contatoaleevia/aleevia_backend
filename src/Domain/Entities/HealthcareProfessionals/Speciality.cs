using CrossCutting.Entities;

namespace Domain.Entities.HealthcareProfessionals;

public class Speciality : AggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public Guid ProfessionId { get; private set; }
    public Profession Profession { get; private set; } = null!;
    public ICollection<SubSpecialty> SubSpecialties { get; private set; } = [];

    public Speciality(string name, Guid professionId)
    {
        Name = name;
        ProfessionId = professionId;
        Active = true;
        CreatedAt = DateTime.UtcNow;
        SubSpecialties = [];
    }

    protected Speciality() { }
} 