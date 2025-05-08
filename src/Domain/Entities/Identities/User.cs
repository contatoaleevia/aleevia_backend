using CrossCutting.Utils;
using Domain.Entities.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identities;

public sealed class User : IdentityUser<Guid>
{
    public string Name { get; private set; }
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
        UserType userType)
    {
        Email = email;
        EmailConfirmed = true;
        PhoneNumber = SetPhoneNumberInternal(phoneNumber);
        PhoneNumberConfirmed = true;
        Name = name;
        Cpf = SetCpf(cpf);
        Cnpj = SetCnpjInternal(cnpj);
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

    public static Document SetCpf(string cpf) => Document.CreateDocumentAsCpf(cpf);

    public void SetName(string name) => Name = string.IsNullOrEmpty(name) ? string.Empty : name.Trim();

    public void SetEmail(string email)
    {
        Email = string.IsNullOrEmpty(email) ? string.Empty : email.Trim();
    }

    public static Document SetCnpjInternal(string? cnpj)
        => string.IsNullOrEmpty(cnpj) ? Document.CreateAsEmptyCnpj() : Document.CreateDocumentAsCnpj(cnpj);

    public void SetCnpj(string? cnpj)
    {
        if (string.IsNullOrEmpty(cnpj))
        {
            Cnpj = Document.CreateAsEmptyCnpj();
            return;
        }
        Cnpj = Document.CreateDocumentAsCnpj(cnpj);
    }

    public ushort GetUserTypeId() => (ushort)UserType.UserTypeId;

    public static string SetPhoneNumberInternal(string? phoneNumber)
    {
        if (phoneNumber is null) return string.Empty;
        phoneNumber = phoneNumber.Replace(" ", string.Empty).Trim();
        if (PhoneNumberValidator.IsValid(phoneNumber))
            throw new ArgumentException("Invalid phone number.");

        return phoneNumber;
    }

    public void SetPhoneNumber(string? phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
        {
            PhoneNumber = string.Empty;
            return;
        }
        PhoneNumber = SetPhoneNumberInternal(phoneNumber);
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
}