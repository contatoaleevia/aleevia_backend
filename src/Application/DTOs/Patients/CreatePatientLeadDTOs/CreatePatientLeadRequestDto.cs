using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Patients.CreatePatientLeadDTOs;

public class CreatePatientLeadRequestDto
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "O telefone é obrigatório")]
    public string Phone { get; set; }
    
    [Required(ErrorMessage = "O CPF é obrigatório")]
    public string Cpf { get; set; }
    
    public DateTime? BirthDate { get; set; }
    
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }
} 