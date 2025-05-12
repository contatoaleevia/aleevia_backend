using Domain.Entities.Identities.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identities;

public sealed class UserRole : IdentityUserRole<Guid>
{
    public Role Role { get; } = null!;
    public User User { get; } = null!;
    
    public UserRole()
    {
    }

    public UserRole(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }

    public string GetRoleName() => Role.GetName();

    public static List<Role> GetRolesByUserType(UserType userType)
        => UserTypeRoles[userType.UserTypeId];
    
    private static readonly Dictionary<UserTypeEnum, List<Role>> UserTypeRoles = new()
    {
        { UserTypeEnum.Manager, [Role.Admin] },
        { UserTypeEnum.Employee, [Role.Employee] },
        { UserTypeEnum.HealthcareProfessional, [Role.Admin, Role.Professional] },
        { UserTypeEnum.Patient, [Role.Patient] }
    };
}