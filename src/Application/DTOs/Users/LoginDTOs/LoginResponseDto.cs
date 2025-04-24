namespace Application.DTOs.Users.LoginDTOs;
public class LoginResponseDto
{
    public LoginResponseDto() { }
    public LoginResponseDto(string token, string userName, string email)
    {
        Token = token;
        UserName = userName;
        Email = email;
    }

    public string Token { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}
