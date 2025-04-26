using Application.DTOs.Users.LoginDTOs;

namespace Application.Services;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto);
}