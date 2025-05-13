using Application.DTOs.Users.PasswordResetDTOs;

namespace Application.Services.PasswordResets;

public interface IPasswordResetService
{
    Task<RequestPasswordResetResponseDTO> RequestPasswordResetAsync(RequestPasswordResetDTO request);
    Task ResetPasswordAsync(ResetPasswordDTO request);
} 