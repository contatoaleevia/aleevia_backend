using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Offices.CreateOfficeDTOs;

public record CreateOfficeRequest
{
    [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres") ]
    [Required(ErrorMessage = "Nome é obrigatório")]
    public required string Name { get; set; }
    public string? Cnpj { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Whatsapp { get; set; }
    public string? Email { get; set; }
    public string? Site { get; set; }
    public string? Instagram { get; set; }
    public string? Logo { get; set; }
}