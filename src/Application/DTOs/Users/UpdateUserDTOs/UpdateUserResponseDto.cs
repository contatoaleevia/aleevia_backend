namespace Application.DTOs.Users.UpdateUserDTOs;

public class UpdateUserResponseDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public UpdateUserResponseDto()
    {
    }

    public UpdateUserResponseDto(Guid id, string userName, string email)
    {
        Id = id;
        UserName = userName;
        Email = email;
    }
}