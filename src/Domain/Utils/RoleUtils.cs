using Microsoft.AspNetCore.Identity;

namespace Domain.Utils;

public static class RoleUtils
{
    public static IdentityRole<Guid> Admin 
        = CreateRole(Guid.Parse("527a61cd-45be-4784-84e5-892ef13de3f3"), "Admin");
    
    public static IdentityRole<Guid> Patient 
        = CreateRole(Guid.Parse("710483d0-680c-4273-99d6-3c0be1940df8"), "Patient");
    
    public static IdentityRole<Guid> Employer 
        = CreateRole(Guid.Parse("4fa64c52-e389-4bbc-be5f-8565081eb393"), "Employer");

    private static IdentityRole<Guid> CreateRole(Guid roleId, string name)
        => new()
        {
            Id = roleId,
            Name = name,
            NormalizedName = name.ToUpper(),
            ConcurrencyStamp = null
        };
}