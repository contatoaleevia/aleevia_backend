using CrossCutting.Entities;
using Domain.Entities.Identities;

namespace Domain.Entities.Patients;

public class Patient : AggregateRoot
{
    public Guid UserId { get; private set; }
    public BloodType? BloodType { get; private set; }
    public BiologicalSex? BiologicalSex { get; private set; }
    public string? PictureUrl { get; private set; }
    public string? GoogleToken { get; private set; }
    public string? GoogleRefreshToken { get; private set; }
    public bool PreRegister { get; private set; }
    public Gender? Gender { get; private set; }
    public DateOnly? BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? RemovedAt { get; private set; }
    
    public User User { get; private set; } = null!;
    
    protected Patient() { }
    
    public Patient(
        Guid userId,
        BloodType? bloodType,
        BiologicalSex? biologicalSex,
        string? pictureUrl,
        Gender? gender,
        DateOnly? birthDate,
        bool preRegister = false)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        BloodType = bloodType;
        BiologicalSex = biologicalSex;
        PictureUrl = pictureUrl;
        PreRegister = preRegister;
        Gender = gender;
        BirthDate = birthDate;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = null;
        RemovedAt = null;
    }
} 