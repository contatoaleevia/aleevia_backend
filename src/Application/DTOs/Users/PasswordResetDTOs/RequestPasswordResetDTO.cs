using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Users.PasswordResetDTOs;

public class RequestPasswordResetDto
{
    [Required(ErrorMessage = "O documento é obrigatório")]
    public required string Document { get; set; }
} 