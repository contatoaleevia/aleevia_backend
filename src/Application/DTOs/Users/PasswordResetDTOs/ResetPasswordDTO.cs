using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Users.PasswordResetDTOs;

public class ResetPasswordDto
{
    [Required(ErrorMessage = "O token é obrigatório")]
    public required string Token { get; set; }

    [Required(ErrorMessage = "O documento é obrigatório")]
    public required string Document { get; set; }

    [Required(ErrorMessage = "A nova senha é obrigatória")]
    [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
    public required string NewPassword { get; set; }

    [Required(ErrorMessage = "A confirmação de senha é obrigatória")]
    [Compare(nameof(NewPassword), ErrorMessage = "As senhas não conferem")]
    public required string ConfirmPassword { get; set; }
} 