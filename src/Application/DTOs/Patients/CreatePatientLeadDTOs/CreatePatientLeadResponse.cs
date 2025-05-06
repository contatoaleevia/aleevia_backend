namespace Application.DTOs.Patients.CreatePatientLeadDTOs;

public class CreatePatientLeadResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Phone { get; set; }
    public required string Cpf { get; set; }
    public DateOnly? BirthDate { get; set; }
    public required string Email { get; set; }
    public required DateTime CreatedAt { get; set; }
} 