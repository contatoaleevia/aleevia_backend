using System.Text.Json.Serialization;
using CrossCutting.Extensions;
using Domain.Entities.Identities.Enums;

namespace Domain.Entities.Identities;

public class UserType
{
    [JsonPropertyName("userTypeId")]
    public UserTypeEnum UserTypeId { get; set; }
    public string UserTypeName => UserTypeId.TryGetDescription();
    
    private UserType()
    {
    }

    [JsonConstructor]
    private UserType(UserTypeEnum userTypeId)
    {
        UserTypeId = userTypeId;
    }
    
    public static UserType CreateAsManager () => new(UserTypeEnum.Manager);
    public static UserType CreateAsPatient () => new(UserTypeEnum.Patient);
    public static UserType CreateAsEmployee () => new(UserTypeEnum.Employee);
    public static UserType CreateAsHealthcareProfessional () => new(UserTypeEnum.HealthcareProfessional);
}