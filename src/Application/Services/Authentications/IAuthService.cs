using Application.DTOs.Users.LoginDTOs;

namespace Application.Services.Authentications;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto);
}