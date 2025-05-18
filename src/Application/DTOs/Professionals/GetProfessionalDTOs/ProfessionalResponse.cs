using Domain.Entities.Professionals;

namespace Application.DTOs.Professionals.GetProfessionalDTOs;

public record ProfessionalResponse
{
    public required ProfessionalData Professional { get; init; }

    public static ProfessionalResponse FromProfessional(Professional professional)
    {
        ArgumentNullException.ThrowIfNull(professional);

        return new ProfessionalResponse
        {
            Professional = new ProfessionalData
            {
                Id = professional.Id,
                Name = professional.Name ?? string.Empty,
                PreferredName = professional.PreferredName ?? string.Empty,
                Email = professional.Email ?? string.Empty,
                Cpf = professional.Cpf.Value,
                Cnpj = professional.Cnpj?.Value ?? string.Empty,
                Website = professional.Website?.Value,
                Instagram = professional.Instagram?.Value,
                Biography = professional.Biography?.Value,
                IsRegistered = professional.IsRegistered,
                SpecialtyDetails = professional.SpecialtyDetails?.Select(s => new ProfessionalSpecialtyDetailResponse
                {
                    Id = s.Id,
                    ProfessionId = s.ProfessionId,
                    SpecialityId = s.SpecialityId,
                    SubspecialityId = s.SubSpecialityId,
                    VideoPresentation = s.VideoPresentation
                }).ToList() ?? [],
                Documents = professional.Documents?.Select(d => new ProfessionalDocumentResponse
                {
                    Id = d.Id,
                    DocumentType = d.DocumentType,
                    DocumentNumber = d.DocumentNumber,
                    DocumentState = d.DocumentState,
                    FrontUrl = d.FrontUrl,
                    BackUrl = d.BackUrl,
                    Validated = d.Validated
                }).ToList() ?? []
            }
        };
    }
}

public record ProfessionalData
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string PreferredName { get; init; }
    public required string Email { get; init; }
    public required string Cpf { get; init; }
    public required string Cnpj { get; init; }
    public string? Website { get; init; }
    public string? Instagram { get; init; }
    public string? Biography { get; init; }
    public required bool IsRegistered { get; init; }
    public required IReadOnlyList<ProfessionalSpecialtyDetailResponse> SpecialtyDetails { get; init; }
    public required IReadOnlyList<ProfessionalDocumentResponse> Documents { get; init; }
}

public record ProfessionalSpecialtyDetailResponse
{
    public required Guid Id { get; init; }
    public required Guid ProfessionId { get; init; }
    public required Guid SpecialityId { get; init; }
    public Guid? SubspecialityId { get; init; }
    public string? VideoPresentation { get; init; }
}

public record ProfessionalDocumentResponse
{
    public required Guid Id { get; init; }
    public required string DocumentType { get; init; }
    public required string DocumentNumber { get; init; }
    public required string DocumentState { get; init; }
    public string? FrontUrl { get; init; }
    public string? BackUrl { get; init; }
    public required bool Validated { get; init; }
} 