using CrossCutting.Entities;
using Domain.Entities.Offices;
using Domain.Entities.ValueObjects;

namespace Domain.Entities.ServiceProviders;
    
public class ServiceProvider : AggregateRoot
{
    public Document Cnpj { get; private set; } = null!;
    public string Name { get; private set; } = string.Empty;
    public string CorporateName { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }
    public Guid OfficeId { get; private set; }
    public Office Office { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private ServiceProvider() { }

    public ServiceProvider(
        string cnpj,
        string name,        
        string corporateName,
        Guid officeId)
    {
        Cnpj = Document.CreateDocumentAsCnpj(cnpj);
        Name = name;
        CorporateName = corporateName;
        OfficeId = officeId;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(
        string? name,
        string? corporateName)
    {
        Name = name ?? Name;
        CorporateName = corporateName ?? CorporateName;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        IsActive = true;
        UpdatedAt = DateTime.UtcNow;
    }
} 