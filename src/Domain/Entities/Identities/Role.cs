using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identities;

public sealed class Role : IdentityRole<Guid>
{
    public override Guid Id { get; set; }
    
    private Role()
    {
    }
    
    public Role(string name) : this()
    {
        Name = name;
        NormalizedName = name.ToUpper();
        ConcurrencyStamp = Guid.NewGuid().ToString();
    }

    public string GetName() => Name!;

    public static readonly Role Admin 
        = CreateRole(Guid.Parse("527a61cd-45be-4784-84e5-892ef13de3f3"), "Admin");
    
    public static readonly Role Patient 
        = CreateRole(Guid.Parse("710483d0-680c-4273-99d6-3c0be1940df8"), "Patient");
    
    public static readonly Role Employee 
        = CreateRole(Guid.Parse("4fa64c52-e389-4bbc-be5f-8565081eb393"), "Employee");

    public static readonly Role Professional
        = CreateRole(Guid.Parse("b0f3a1c2-4d8e-4b5c-9f7d-6a0e1f3b2c5e"), "Professional");

    private static Role CreateRole(Guid roleId, string name)
        => new()
        {
            Id = roleId,
            Name = name,
            NormalizedName = name.ToUpper(),
            ConcurrencyStamp = Guid.NewGuid().ToString()
        };
}