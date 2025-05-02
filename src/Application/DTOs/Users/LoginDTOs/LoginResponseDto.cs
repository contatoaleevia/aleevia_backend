namespace Application.DTOs.Users.LoginDTOs;
public class LoginResponseDto(string token, string userName, string email)
{
    public string Token { get; set; } = token;
    public string UserName { get; set; } = userName;
    public string Email { get; set; } = email;
}
