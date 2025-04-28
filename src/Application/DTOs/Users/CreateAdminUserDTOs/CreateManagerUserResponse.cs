namespace Application.DTOs.Users.CreateAdminUserDTOs;

public record CreateManagerUserResponse(Guid Id)
{
    public Guid Id { get; set; } = Id;
}