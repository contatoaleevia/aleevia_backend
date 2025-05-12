using Domain.Entities.Offices;

namespace Application.DTOs.Offices.GetOfficeDTOs;

public record GetOfficeProfessionalsResponse
{
    public required IReadOnlyList<OfficeProfessionalData> Professionals { get; init; }

    public static GetOfficeProfessionalsResponse FromOffice(
        Office office,
        IEnumerable<OfficesProfessional> professionals)
    {
        ArgumentNullException.ThrowIfNull(office);
        ArgumentNullException.ThrowIfNull(professionals);

        return new GetOfficeProfessionalsResponse
        {
            Professionals = [.. professionals.Select(p => new OfficeProfessionalData
            {
                Id = p.Id,
                ProfessionalId = p.ProfessionalId,
                IsPublic = p.IsPublic,
                IsActive = p.IsActive,
                Professional = p.Professional == null ? null : new ProfessionalData
                {
                    Id = p.Professional.Id,
                    Name = p.Professional.Name ?? string.Empty,
                    PreferredName = p.Professional.PreferredName ?? string.Empty,
                    Email = p.Professional.Email ?? string.Empty,
                    Cpf = p.Professional.Cpf.Value,
                    Cnpj = p.Professional.Cnpj?.Value,
                    Website = p.Professional.Website?.Value,
                    Instagram = p.Professional.Instagram?.Value,
                    Biography = p.Professional.Biography?.Value,
                    IsRegistered = p.Professional.IsRegistered,
                    RegisterStatus = p.Professional.RegisterStatus.StatusTypeName,
                    SpecialtyDetails = [.. p.Professional.SpecialtyDetails.Select(s => new ProfessionalSpecialtyDetailData
                    {
                        ProfessionId = s.ProfessionId,
                        ProfessionName = s.Profession.Name,
                        SpecialityId = s.SpecialityId,
                        SpecialityName = s.Speciality.Name,
                        SubspecialityId = s.SubspecialityId,
                        SubspecialityName = s.Subspeciality?.Name,
                        VideoPresentation = s.VideoPresentation
                    })],
                    Documents = [.. p.Professional.Documents.Select(d => new ProfessionalDocumentData
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
            })]
        };
    }
}

public record OfficeProfessionalData
{
    public required Guid Id { get; init; }
    public required Guid ProfessionalId { get; init; }
    public required bool IsPublic { get; init; }
    public required bool IsActive { get; init; }
    public ProfessionalData? Professional { get; init; }
}

public record ProfessionalData
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
    public required IReadOnlyList<ProfessionalSpecialtyDetailData> SpecialtyDetails { get; init; }
    public required IReadOnlyList<ProfessionalDocumentData> Documents { get; init; }
}

public record ProfessionalSpecialtyDetailData
{
    public required Guid ProfessionId { get; init; }
    public required string ProfessionName { get; init; }
    public required Guid SpecialityId { get; init; }
    public required string SpecialityName { get; init; }
    public Guid? SubspecialityId { get; init; }
    public string? SubspecialityName { get; init; }
    public string? VideoPresentation { get; init; }
}

public record ProfessionalDocumentData
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