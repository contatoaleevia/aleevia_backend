using Domain.Entities.Patients;

namespace Application.DTOs.Patients.CreatePatientDTOs;

public class CreatePatientResponseDto
{
    public required Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Cpf { get; set; }
    public string? Cnpj { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? BloodType { get; set; }
    public string? BiologicalSex { get; set; }
    public string? PictureUrl { get; set; }
    public string? Gender { get; set; }
    public required bool PreRegister { get; set; }
    public required DateTime CreatedAt { get; set; }
} 