using CrossCutting.Entities;
using Domain.Entities.HealthcareProfessionals;

namespace Domain.Entities.Professionals;

public class ProfessionalSpecialtyDetail : Entity
{
    public Guid ProfessionalId { get; private set; }
    public Professional Professional { get; private set; } = null!;
    public Guid ProfessionId { get; private set; }
    public Profession Profession { get; private set; } = null!;
    public Guid SpecialityId { get; private set; }
    public Specialty Speciality { get; private set; } = null!;
    public Guid? SubspecialityId { get; private set; }
    public SubSpecialty? Subspeciality { get; private set; }
    public string? VideoPresentation { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? RemovedAt { get; private set; }

    public ProfessionalSpecialtyDetail(
        Guid professionalId,
        Guid professionId,
        Guid specialityId,
        Guid? subspecialityId = null,
        string? videoPresentation = null)
    {
        ProfessionalId = professionalId;
        ProfessionId = professionId;
        SpecialityId = specialityId;
        SubspecialityId = subspecialityId;
        VideoPresentation = videoPresentation;
        CreatedAt = DateTime.UtcNow;
    }

    protected ProfessionalSpecialtyDetail() { }

    public void Update(string? videoPresentation)
    {
        VideoPresentation = videoPresentation;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Remove()
    {
        RemovedAt = DateTime.UtcNow;
    }
} 