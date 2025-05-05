using System.ComponentModel.DataAnnotations;
using Domain.Entities.Patients;

namespace Application.DTOs.Patients.CreatePatientDTOs;

public class CreatePatientRequestDto
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O telefone é obrigatório")]
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "O CPF é obrigatório")]
    public string Cpf { get; set; }
    
    public string? Cnpj { get; set; }

    public string? Password { get; set; }
    
    public DateTime? BirthDate { get; set; }
    
    public BloodType? BloodType { get; set; }
    
    public BiologicalSex? BiologicalSex { get; set; }
    
    public string? PictureUrl { get; set; }
    
    public Gender? Gender { get; set; }
    
    public string? GoogleToken { get; set; }
    
    public string? GoogleRefreshToken { get; set; }
    
    public bool PreRegister { get; set; } = false;
} 