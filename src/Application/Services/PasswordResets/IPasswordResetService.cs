using Application.DTOs.Users.PasswordResetDTOs;

namespace Application.Services.PasswordResets;

public interface IPasswordResetService
{
    Task<RequestPasswordResetResponseDto> RequestPasswordResetAsync(RequestPasswordResetDto request);
    Task ResetPasswordAsync(ResetPasswordDto request);
} 