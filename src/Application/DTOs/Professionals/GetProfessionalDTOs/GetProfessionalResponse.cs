using Domain.Entities.Professionals;

namespace Application.DTOs.Professionals.GetProfessionalDTOs;

public class GetProfessionalResponse
{
    public required ProfessionalResponseData Professional { get; init; }

    public static GetProfessionalResponse FromProfessional(Professional professional)
    {
        ArgumentNullException.ThrowIfNull(professional);

        return new GetProfessionalResponse
        {
            Professional = new ProfessionalResponseData
            {
                Id = professional.Id,
                Name = professional.Name ?? string.Empty,
                PreferredName = professional.PreferredName ?? string.Empty,
                Email = professional.Email ?? string.Empty,
                Cpf = professional.Cpf.Value,
                Cnpj = professional.Cnpj?.Value,
                Website = professional.Website?.Value,
                Instagram = professional.Instagram?.Value,
                Biography = professional.Biography?.Value,
                IsRegistered = professional.IsRegistered,
                RegisterStatus = professional.RegisterStatus.StatusTypeName,
                SpecialtyDetails = [.. professional.SpecialtyDetails.Select(s => new ProfessionalSpecialtyDetailResponseData
                {
                    ProfessionId = s.ProfessionId,
                    ProfessionName = s.Profession.Name,
                    SpecialityId = s.SpecialityId,
                    SpecialityName = s.Speciality.Name,
                    SubspecialityId = s.SubspecialityId,
                    SubspecialityName = s.Subspeciality?.Name,
                    VideoPresentation = s.VideoPresentation
                })],
                Documents = [.. professional.Documents.Select(d => new ProfessionalDocumentResponseData
                {
                    Id = d.Id,
                    DocumentType = d.DocumentType,
                    DocumentNumber = d.DocumentNumber,
                    DocumentState = d.DocumentState,
                    FrontUrl = d.FrontUrl,
                    BackUrl = d.BackUrl,
                    Validated = d.Validated,
                    CreatedAt = d.CreatedAt,
                    RemovedAt = d.RemovedAt
                })]
            }
        };
    }
}

public class ProfessionalResponseData
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string PreferredName { get; init; }
    public required string Email { get; init; }
    public required string Cpf { get; init; }
    public string? Cnpj { get; init; }
    public string? Website { get; init; }
    public string? Instagram { get; init; }
    public string? Biography { get; init; }
    public required bool IsRegistered { get; init; }
    public required string RegisterStatus { get; init; }
    public required List<ProfessionalSpecialtyDetailResponseData> SpecialtyDetails { get; init; }
    public required List<ProfessionalDocumentResponseData> Documents { get; init; }
}

public class ProfessionalSpecialtyDetailResponseData
{
    public required Guid ProfessionId { get; init; }
    public required string ProfessionName { get; init; }
    public required Guid SpecialityId { get; init; }
    public required string SpecialityName { get; init; }
    public Guid? SubspecialityId { get; init; }
    public string? SubspecialityName { get; init; }
    public string? VideoPresentation { get; init; }
}

public class ProfessionalDocumentResponseData
{
    public required Guid Id { get; init; }
    public required string DocumentType { get; init; }
    public required string DocumentNumber { get; init; }
    public required string DocumentState { get; init; }
    public string? FrontUrl { get; init; }
    public string? BackUrl { get; init; }
    public required bool Validated { get; init; }
    public required DateTime CreatedAt { get; init; }
    public DateTime? RemovedAt { get; init; }
} 