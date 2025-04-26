using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ServiceTypes.CreateServiceTypeDTOs;

public class CreateServiceTypeRequestDto
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name must be between 3 and 100 characters", MinimumLength = 3)]
    public string Name { get; set; } = null!;
    
    [StringLength(500, ErrorMessage = "Description must not exceed 500 characters")]
    public string? Description { get; set; }
} 