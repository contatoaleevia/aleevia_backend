using CrossCutting.Entities;

namespace Domain.Entities.Professionals;

public class ProfessionalDocument : Entity
{
    public Guid ProfessionalId { get; private set; }
    public Professional Professional { get; private set; } = null!;
    public string DocumentType { get; private set; } = string.Empty;
    public string DocumentNumber { get; private set; } = string.Empty;
    public string DocumentState { get; private set; } = string.Empty;
    public string? FrontUrl { get; private set; }
    public string? BackUrl { get; private set; }
    public bool Validated { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? RemovedAt { get; private set; }

    public ProfessionalDocument(
        Guid professionalId,
        string documentType,
        string documentNumber,
        string documentState,
        string? frontUrl = null,
        string? backUrl = null)
    {
        ProfessionalId = professionalId;
        DocumentType = documentType;
        DocumentNumber = documentNumber;
        DocumentState = documentState;
        FrontUrl = frontUrl;
        BackUrl = backUrl;
        Validated = false;
        CreatedAt = DateTime.UtcNow;
    }

    protected ProfessionalDocument() { }

    public void UpdateUrls(string? frontUrl, string? backUrl)
    {
        FrontUrl = frontUrl;
        BackUrl = backUrl;
    }

    public void Validate()
    {
        Validated = true;
    }

    public void Remove()
    {
        RemovedAt = DateTime.UtcNow;
    }
} 