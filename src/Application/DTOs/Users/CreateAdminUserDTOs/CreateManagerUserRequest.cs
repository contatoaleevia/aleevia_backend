using JetBrains.Annotations;

namespace Application.DTOs.Users.CreateAdminUserDTOs;

public class CreateManagerUserRequest
{
    public string Password { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string? Cnpj { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public CreateManagerRequest Manager { get; set; } = null!;
}

[UsedImplicitly]
public class CreateManagerRequest
{
    public ushort TypeId { get; set; } 
    public string? CorporateName { get; set; }
}