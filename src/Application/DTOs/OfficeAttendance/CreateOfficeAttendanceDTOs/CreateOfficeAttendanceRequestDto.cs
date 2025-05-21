using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.OfficeAttendance.CreateOfficeAttendanceDTOs;

public class CreateOfficeAttendanceRequestDto
{
    [Required(ErrorMessage = "ID do local de atendimento é obrigatório")]
    public Guid OfficeId { get; set; }

    [Required(ErrorMessage = "ID do tipo de serviço é obrigatório")]
    public Guid ServiceTypeId { get; set; }

    [Required(ErrorMessage = "Título é obrigatório")]
    [StringLength(100, ErrorMessage = "Título deve conter entre 3 e 100 caracteres", MinimumLength = 3)]
    public string Title { get; set; } = null!;

    [StringLength(500, ErrorMessage = "Descrição não deve conter mais de 500 caracteres")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Preço é obrigatório")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Duração é obrigatória")]
    [Range(1, int.MaxValue, ErrorMessage = "Duração deve ser maior que 0")]
    public int Duration { get; set; }
} 