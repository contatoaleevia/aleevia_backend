using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.HealthCares.CreateHealthCareDTOs;

public record CreateHealthCareRequest
{
    [Required(ErrorMessage = "ID do consultório é obrigatório")]
    public required Guid OfficeId { get; init; }

    [Required(ErrorMessage = "Nome do convênio é obrigatório")]
    public required string Name { get; init; }
    public string? AnsNumber { get; init; }
    public string? Registry { get; init; }

    [Required(ErrorMessage = "IsActive é obrigatório")]
    public required bool IsActive { get; init; }
}