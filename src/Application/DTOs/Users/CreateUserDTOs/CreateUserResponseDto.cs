namespace Application.DTOs.Users.CreateUserDTOs;

public class CreateUserResponseDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public CreateUserResponseDto()
    {
    }
    
    public CreateUserResponseDto(Guid id, string userName, string email)
    {
        Id = id;
        UserName = userName;
        Email = email;
    }
}