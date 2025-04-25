using Domain.Utils;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identities;

public sealed class User : IdentityUser<Guid>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PreferredName { get; private set; }
    public string Gender { get; private set; }
    public Document Document { get; private set; }
    public UserType UserType { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public bool Active { get; private set; }
    public ICollection<IdentityUserRole<Guid>> UserRoles { get; private set; } = new List<IdentityUserRole<Guid>>();

    private User()
    {
    }

    public User(
        string email,
        string? phoneNumber,
        string firstName,
        string lastName,
        string preferredName,
        string gender,
        string document,
        ushort userType)
    {
        Email = email;
        EmailConfirmed = true;
        PhoneNumber = phoneNumber;
        PhoneNumberConfirmed = true;
        Gender = gender;
        FirstName = firstName;
        LastName = lastName;
        PreferredName = preferredName;
        Document = new Document(document);
        UserType = new UserType(userType);
        Active = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = null;
        DeletedAt = null;
        TwoFactorEnabled = false;
        LockoutEnabled = false;
        LockoutEnd = null;
        AccessFailedCount = 0;
        UserName = Document.Value;
    }

    public void AddRoleAdmin() => AddRole(RoleUtils.Admin.Id);
    
    private void AddRole(Guid roleId)
    {
        UserRoles.Add(new IdentityUserRole<Guid>
        {
            UserId = Id,
            RoleId = roleId
        });
    }
}