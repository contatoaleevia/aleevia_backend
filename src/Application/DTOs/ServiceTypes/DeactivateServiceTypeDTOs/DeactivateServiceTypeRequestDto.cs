using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ServiceTypes.DeactivateServiceTypeDTOs;

public class DeactivateServiceTypeRequestDto
{
    [Required(ErrorMessage = "Id is required")]
    public Guid Id { get; set; }
} 