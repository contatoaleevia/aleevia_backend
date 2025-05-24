using CrossCutting.Entities;
using Domain.Entities.ValueObjects;
using JetBrains.Annotations;

namespace Domain.Entities.Patients;

public class PatientLead : AggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public Document Cpf { get; private set; } = null!;
    public DateOnly? BirthDate { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public bool Approved { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? RemovedAt { get; private set; }
    
    [UsedImplicitly]
    private PatientLead() { }
    
    public PatientLead(
        string name,
        string phone,
        string cpf,
        DateOnly? birthDate,
        string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Phone = phone;
        Cpf = Document.CreateDocumentAsCpf(cpf);
        BirthDate = birthDate;
        Email = email;
        Approved = false;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = null;
        RemovedAt = null;
    }
} 