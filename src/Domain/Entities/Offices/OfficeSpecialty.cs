using CrossCutting.Entities;
using Domain.Entities.HealthcareProfessionals;

namespace Domain.Entities.Offices;

public class OfficeSpecialty : AggregateRoot
{
    public Guid OfficeId { get; private set; }
    public Guid SpecialtyId { get; private set; }
    public bool IsActive { get; private set; }

    public Office Office { get; private set; } = null!;
    public Speciality Speciality { get; private set; } = null!;

    public OfficeSpecialty(Guid officeId, Guid specialtyId)
    {
        OfficeId = officeId;
        SpecialtyId = specialtyId;
        IsActive = true;
    }

    protected OfficeSpecialty() { }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
} 