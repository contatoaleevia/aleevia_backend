using System.ComponentModel.DataAnnotations;
using Domain.Entities.Patients;

namespace Application.DTOs.Patients.CreatePatientDTOs;

public class CreatePatientUserRequest
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public required string Name { get; set; }
    
    public string? PreferredName { get; set; }
    
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public required string Email { get; set; }
    
    [Required(ErrorMessage = "O telefone é obrigatório")]
    public required string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "O CPF é obrigatório")]
    public required string Cpf { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória")]
    public required string Password { get; set; }
    
    public DateOnly? BirthDate { get; set; }
    
    public BloodType? BloodType { get; set; }
    
    public BiologicalSex? BiologicalSex { get; set; }
    
    public string? PictureUrl { get; set; }
    
    public Gender? Gender { get; set; }
    
    public bool PreRegister { get; set; } = false;
} 