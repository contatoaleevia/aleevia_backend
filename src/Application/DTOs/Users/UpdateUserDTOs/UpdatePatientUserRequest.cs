using Domain.Entities.Patients;

namespace Application.DTOs.Users.UpdateUserDTOs;

public class UpdatePatientUserRequest
{
    public string? Name { get; set; }
    public string? PreferredName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public DateOnly? BirthDate { get; set; }
    
    // Patient specific fields
    public BloodType? BloodType { get; set; }
    public BiologicalSex? BiologicalSex { get; set; }
    public string? PictureUrl { get; set; }
    public Gender? Gender { get; set; }
} 