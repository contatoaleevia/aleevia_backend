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
}