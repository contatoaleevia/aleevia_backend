using CrossCutting.Extensions;

namespace Domain.Entities.Identities;

public class UserType
{
    public UserTypeEnum UserTypeId { get; set; }
    public string UserTypeName => UserTypeId.TryGetDescription();
    
    private UserType()
    {
    }

    public UserType(ushort userTypeId)
    {
        UserTypeId = (UserTypeEnum) userTypeId;
    }
}