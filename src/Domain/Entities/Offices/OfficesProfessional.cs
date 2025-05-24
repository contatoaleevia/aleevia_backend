using CrossCutting.Entities;
using Domain.Entities.Professionals;
using JetBrains.Annotations;

namespace Domain.Entities.Offices;
public class OfficesProfessional : AggregateRoot
{
    [UsedImplicitly]
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

    public void Deactivate()
    {
        IsActive = false;
        DeletedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        IsActive = true;
        DeletedAt = null;
    }

    public string? GetProfessionalName() => Professional.Name;
    public string? GetProfessionalPreferredName() => Professional.PreferredName;
    public string? GetProfessionalEmail() => Professional.Email;
    public string GetProfessionalCpfFormatted() => Professional.Cpf.GetFormattedValue();
    public string? GetProfessionalCnpjFormatted() => Professional.Cnpj?.GetFormattedValue();
}