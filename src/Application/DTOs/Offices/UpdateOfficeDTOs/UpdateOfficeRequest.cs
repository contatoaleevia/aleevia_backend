using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Application.DTOs.Offices.UpdateOfficeDTOs;

public record UpdateOfficeRequest
{
    public required Guid Id { get; init; }
    
    [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
    public string? Name { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Whatsapp { get; init; }
    public string? Email { get; init; }
    public string? Site { get; init; }
    public string? Instagram { get; init; }
    public IFormFile? Logo { get; init; }
} 