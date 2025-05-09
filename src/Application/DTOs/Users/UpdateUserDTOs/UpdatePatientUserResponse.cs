using Domain.Entities.Identities;
using Domain.Entities.Patients;
using Application.DTOs.Users.RetrieveUserDTOs;

namespace Application.DTOs.Users.UpdateUserDTOs;

public record UpdatePatientUserResponse
{
    // User data
    public required Guid UserId { get; init; }
    public required string Name { get; init; }
    public string? PhoneNumber { get; init; }
    public required string Email { get; init; }
    
    // Patient data
    public required Guid PatientId { get; init; }
    public string? PreferredName { get; init; }
    public DateOnly? BirthDate { get; init; }
    public BloodType? BloodType { get; init; }
    public BiologicalSex? BiologicalSex { get; init; }
    public string? PictureUrl { get; init; }
    public Gender? Gender { get; init; }
    public required DateTime UpdatedAt { get; init; }

    public static UpdatePatientUserResponse FromUser(User user, Patient patient)
    {
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(patient);

        return new UpdatePatientUserResponse
        {
            // User data
            UserId = user.Id,
            Name = user.Name,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email ?? throw new InvalidOperationException("Email nao pode ser nulo"),
            
            // Patient data
            PatientId = patient.Id,
            PreferredName = patient.PreferredName,
            BirthDate = patient.BirthDate,
            BloodType = patient.BloodType,
            BiologicalSex = patient.BiologicalSex,
            PictureUrl = patient.PictureUrl,
            Gender = patient.Gender,
            UpdatedAt = DateTime.UtcNow
        };
    }
}

public record PatientData
{
    public required Guid Id { get; init; }
    public BloodType? BloodType { get; init; }
    public BiologicalSex? BiologicalSex { get; init; }
    public string? PictureUrl { get; init; }
    public Gender? Gender { get; init; }
    public DateOnly? BirthDate { get; init; }
} 