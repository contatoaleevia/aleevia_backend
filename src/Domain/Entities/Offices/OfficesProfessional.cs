using CrossCutting.Entities;
using Domain.Entities.Professionals;

namespace Domain.Entities.Offices;
public class OfficesProfessional : AggregateRoot
{
    private OfficesProfessional()
    {
    }

    public OfficesProfessional(
        Guid officeId,
        Guid professionalId,
        bool isPublic,
        bool isActive)
    {
        OfficeId = officeId;
        ProfessionalId = professionalId;
        IsPublic = isPublic;
        IsActive = isActive;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = null;
        DeletedAt = isActive ? null : DateTime.UtcNow;
    }

    public Office Office { get; set; } = null!;
    public Guid OfficeId { get; set; }
    public Professional Professional { get; set; } = null!;
    public Guid ProfessionalId { get; set; }
    public bool IsPublic { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
}