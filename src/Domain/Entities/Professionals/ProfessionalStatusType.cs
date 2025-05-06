using CrossCutting.Extensions;

namespace Domain.Entities.Professionals;
public class ProfessionalStatusType
{
    public ProfessionalStatusEnum StatusType { get; set; }
    public string StatusTypeName => StatusType.TryGetDescription();

    private ProfessionalStatusType()
    {
    }

    public ProfessionalStatusType(ushort statusType)
    {
        StatusType = (ProfessionalStatusEnum)statusType;
    }
}