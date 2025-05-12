using Application.DTOs.Users.PasswordResetDTOs;

namespace Application.Services.PasswordResets;

public interface IPasswordResetService
{
    Task RequestPasswordResetAsync(RequestPasswordResetDTO request);
    Task ResetPasswordAsync(ResetPasswordDTO request);
} 