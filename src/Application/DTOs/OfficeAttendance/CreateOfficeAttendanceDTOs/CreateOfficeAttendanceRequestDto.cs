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
    [Range(0.01, 99999.99, ErrorMessage = "Preço deve ser maior que zero")]
    public long Price { get; set; }
} 