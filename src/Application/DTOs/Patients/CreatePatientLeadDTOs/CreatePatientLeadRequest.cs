using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Patients.CreatePatientLeadDTOs;

public class CreatePatientLeadRequest
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public required string Name { get; set; }
    
    [Required(ErrorMessage = "O telefone é obrigatório")]
    public required string Phone { get; set; }
    
    [Required(ErrorMessage = "O CPF é obrigatório")]
    public required string Cpf { get; set; }
    
    public DateOnly? BirthDate { get; set; }
    
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public required string Email { get; set; }
} 