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
    public UserTypeEnum UserType { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public bool Active { get; private set; }

    private User(Document document)
    {
        Document = document;
    }

    public User(
        string userName,
        string email,
        string? phoneNumber,
        string gender,
        string firstName,
        string lastName,
        string preferredName,
        bool active, 
        string document)
    {
        UserName = userName;
        Email = email;
        EmailConfirmed = true;
        PhoneNumber = phoneNumber;
        PhoneNumberConfirmed = true;
        Gender = gender;
        FirstName = firstName;
        LastName = lastName;
        PreferredName = preferredName;
        Active = active;
        Document = new Document(document);

        TwoFactorEnabled = false;
        LockoutEnabled = false;
        LockoutEnd = null;
        AccessFailedCount = 0;
    }
}