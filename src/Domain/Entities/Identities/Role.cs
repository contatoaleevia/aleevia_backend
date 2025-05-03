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
}