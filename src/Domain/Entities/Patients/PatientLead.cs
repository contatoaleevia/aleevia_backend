using CrossCutting.Entities;
using Domain.Entities.ValueObjects;

namespace Domain.Entities.Patients;

public class PatientLead : AggregateRoot
{
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public Document Cpf { get; private set; }
    public DateOnly? BirthDate { get; private set; }
    public string Email { get; private set; }
    public bool Approved { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? RemovedAt { get; private set; }
    
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
    
    public void Approve()
    {
        Approved = true;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Update(
        string name,
        string phone,
        string email,
        DateOnly? birthDate)
    {
        Name = name;
        Phone = phone;
        Email = email;
        BirthDate = birthDate;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Remove()
    {
        RemovedAt = DateTime.UtcNow;
    }
} 