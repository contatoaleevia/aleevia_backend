using CrossCutting.Utils;
using Domain.Entities.ValueObjects;
using Domain.Utils;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identities;

public sealed class User : IdentityUser<Guid>
{
    public string Name { get; private set; }
    public string? PreferredName { get; private set; }
    public Document Cpf { get; private set; }
    public Document Cnpj { get; private set; }
    public UserType UserType { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public bool Active { get; private set; }

    public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();

    public Manager? Manager { get; private set; }

    private User()
    {
    }

    public User(
        string email,
        string? phoneNumber,
        string name,
        string cpf,
        string? cnpj,
        UserType userType,
        string? preferredName = null)
    {
        Email = email;
        EmailConfirmed = true;
        PhoneNumber = SetPhoneNumber(phoneNumber);
        PhoneNumberConfirmed = true;
        Name = name;
        PreferredName = preferredName;
        Cpf = SetCpf(cpf);
        Cnpj = SetCnpj(cnpj);
        UserType = userType;
        Active = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = null;
        DeletedAt = null;
        TwoFactorEnabled = false;
        LockoutEnabled = false;
        LockoutEnd = null;
        AccessFailedCount = 0;
        UserName = cpf;
        UserRoles = SetRolesByUserType(userType);
    }

    public void Update(
        string? name = null,
        string? preferredName = null,
        string? phoneNumber = null,
        string? email = null)
    {
        if (name is not null)
            Name = name;
            
        if (preferredName is not null)
            PreferredName = preferredName;
            
        if (phoneNumber is not null)
            PhoneNumber = SetPhoneNumber(phoneNumber);
            
        if (email is not null)
            Email = email;
            
        UpdatedAt = DateTime.UtcNow;
    }

    public Document SetCpf(string cpf) => Document.CreateDocumentAsCpf(cpf);

    public Document SetCnpj(string? cnpj)
        => string.IsNullOrEmpty(cnpj) ? Document.CreateAsEmptyCnpj() : Document.CreateDocumentAsCnpj(cnpj);
    public ushort GetUserTypeId() => (ushort)UserType.UserTypeId;

    public string SetPhoneNumber(string? phoneNumber)
    {
        if (phoneNumber is null) return string.Empty;
        phoneNumber = phoneNumber.Replace(" ", string.Empty).Trim();
        if (PhoneNumberValidator.IsValid(phoneNumber))
            throw new ArgumentException("Invalid phone number.");

        return phoneNumber;
    }

    public IEnumerable<string> GetRolesNames() => UserRoles.Select(x => x.GetRoleName());

    private ICollection<UserRole> SetRolesByUserType(UserType userType)
    {
        var roles = UserRole.GetRolesByUserType(userType);
        return [.. roles.Select(x => new UserRole(Id, x.Id))];
    }

    public void SetRole(Role role)
    {
        if (UserRoles.All(x => x.RoleId != role.Id))
            UserRoles.Add(new UserRole(Id, role.Id));
    }

    public void UpdateFromRegister(string cnpj, string phone)
    {
        Cnpj = SetCnpj(cnpj);
        PhoneNumber = SetPhoneNumber(phone);
        UpdatedAt = DateTime.UtcNow;
    }
}