using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Users.PasswordResetDTOs;

public class RequestPasswordResetDTO
{
    [Required(ErrorMessage = "O documento é obrigatório")]
    public required string Document { get; set; }
} 