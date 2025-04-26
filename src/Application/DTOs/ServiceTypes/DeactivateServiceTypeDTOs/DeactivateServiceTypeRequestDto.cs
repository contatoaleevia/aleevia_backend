using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ServiceTypes.DeactivateServiceTypeDTOs;

public class DeactivateServiceTypeRequestDto
{
    [Required(ErrorMessage = "Id é obrigatório")]
    public Guid Id { get; set; }
} 