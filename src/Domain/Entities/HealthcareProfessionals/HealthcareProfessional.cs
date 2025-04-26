using System.Reflection.Metadata;
using CrossCutting.Entities;

namespace Domain.Entities.HealthcareProfessionals;

public class HealthcareProfessional : AggregateRoot
{
    public Guid UserId { get; set; }
    public Document Document { get; set; }
    
}