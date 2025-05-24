using Domain.Entities.Identities;

namespace Application.DTOs.Users.LoginDTOs;

public record LoginResponseDto
{
    public required string Token { get; init; }
    public required UserData User { get; init; }

    public static LoginResponseDto FromUser(User user, string token, Manager? manager)
    {
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(token);

        return new LoginResponseDto
        {
            Token = token,
            User = new UserData
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName ?? throw new InvalidOperationException("UserName nao pode ser nulo"),
                Email = user.Email ?? throw new InvalidOperationException("Email nao pode ser nulo"),
                PhoneNumber = user.PhoneNumber ?? throw new InvalidOperationException("PhoneNumber nao pode ser nulo"),
                Cpf = user.Cpf.Value,
                Cnpj = user.Cnpj.Value,
                UserType = user.GetUserTypeId(),
                UserTypeName = user.UserType.UserTypeName,
                Active = user.Active,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                Roles = [.. user.UserRoles.Select(x => new UserRoleData{ Id = x.RoleId, Name = x.GetRoleName() })],
                ManagerId = manager?.Id,
                ManagerTypeId = manager?.GetTypeId()
            }
        };
    }
}

public record UserData
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string UserName { get; init; }
    public required string Email { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Cpf { get; init; }
    public required string Cnpj { get; init; }
    public required ushort UserType { get; init; }
    public required string UserTypeName { get; init; }
    public required bool Active { get; init; }
    public required DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public required IReadOnlyList<UserRoleData> Roles { get; init; }
    public Guid? ManagerId { get; init; }
    public ushort? ManagerTypeId { get; init; }
}

public record UserRoleData
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}
