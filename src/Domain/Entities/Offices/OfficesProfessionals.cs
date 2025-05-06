using CrossCutting.Entities;
using Domain.Entities.Professionals;

namespace Domain.Entities.Offices;
public class OfficesProfessionals : AggregateRoot
{
    public OfficesProfessionals()
    {
    }

    public OfficesProfessionals(
        Guid officeId,
        Guid professionalId)
    {
        OfficeId = officeId;
        ProfessionalId = professionalId;
        CreatedAt = DateTime.Now;
    }

    public Office Office { get; set; }
    public Guid OfficeId { get; set; }
    public Professional Professional { get; set; }
    public Guid ProfessionalId { get; set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
}