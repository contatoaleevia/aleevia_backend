using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.ServiceTypes.CreateServiceTypeDTOs;

public class CreateServiceTypeRequestDto
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(100, ErrorMessage = "Nome deve conter entre 3 e 100 caracteres", MinimumLength = 3)]
    public string Name { get; set; } = null!;
    
    [StringLength(500, ErrorMessage = "Descrição não deve conter mais de 500 caracteres")]
    public string? Description { get; set; }
} 