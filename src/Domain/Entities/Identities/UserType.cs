using CrossCutting.Extensions;
using Domain.Entities.Identities.Enums;

namespace Domain.Entities.Identities;

public class UserType
{
    public UserTypeEnum UserTypeId { get; set; }
    public string UserTypeName => UserTypeId.TryGetDescription();
    
    private UserType()
    {
    }

    private UserType(UserTypeEnum userTypeId)
    {
        UserTypeId = userTypeId;
    }
    
    public static UserType CreateAsManager () => new(UserTypeEnum.Manager);
    
    public static UserType Employee => new(UserTypeEnum.Employee);
    public static UserType HealthcareProfessional => new(UserTypeEnum.HealthcareProfessional);
    public static UserType Manager => new(UserTypeEnum.Manager);
    public static UserType Patient => new(UserTypeEnum.Patient);
}