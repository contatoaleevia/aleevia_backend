using System.Text.Json.Serialization;
using CrossCutting.Extensions;

namespace Domain.Entities.Professionals;
public class ProfessionalRegisterStatus
{
    public ProfessionalStatusEnum StatusType { get; set; }
    public string StatusTypeName => StatusType.TryGetDescription();

    private ProfessionalRegisterStatus()
    {
    }

    [JsonConstructor]
    private ProfessionalRegisterStatus(ProfessionalStatusEnum statusType)
    {
        StatusType = statusType;
    }

    public ProfessionalRegisterStatus(ushort statusType)
    {
        StatusType = (ProfessionalStatusEnum)statusType;
    }
    
    public static ProfessionalRegisterStatus CreateAsPending() => new(ProfessionalStatusEnum.Pending);
}