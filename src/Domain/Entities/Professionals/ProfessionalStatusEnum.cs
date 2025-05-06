using System.ComponentModel;

namespace Domain.Entities.Professionals;
public enum ProfessionalStatusEnum
{
    [Description("Pendente")]
    Pending = 0,
    [Description("Aprovado")]
    Approved = 1,
    [Description("Recusado")]
    Declined = 2
}