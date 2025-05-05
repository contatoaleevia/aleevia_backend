using CrossCutting.Entities;
using Domain.Entities.ValueObjects;

namespace Domain.Entities.Patients;

public class PatientLead : AggregateRoot
{
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public Document Cpf { get; private set; }
    public DateTime? BirthDate { get; private set; }
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
        DateTime? birthDate,
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
        string email)
    {
        Name = name;
        Phone = phone;
        Email = email;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Remove()
    {
        RemovedAt = DateTime.UtcNow;
    }
} 