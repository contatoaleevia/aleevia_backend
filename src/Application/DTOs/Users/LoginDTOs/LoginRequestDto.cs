namespace Application.DTOs.Users.LoginDTOs;
public class LoginRequestDto
{
    public LoginRequestDto(string email, string password, bool rememberMe)
    {
        Email = email;
        Password = password;
        RememberMe = rememberMe;
    }

    public string Email { get; set; }

    public string Password { get; set; }
    public bool RememberMe { get; set; } = false;
}