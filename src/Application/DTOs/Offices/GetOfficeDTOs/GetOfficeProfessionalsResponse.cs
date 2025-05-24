using Domain.Entities.Offices;
using Domain.Entities.Professionals;
using JetBrains.Annotations;

namespace Application.DTOs.Offices.GetOfficeDTOs;

public record GetOfficeProfessionalsResponse
{
    public required IReadOnlyList<OfficeProfessionalData> Professionals { get; init; }

    public static GetOfficeProfessionalsResponse FromOffice(
        Office office,
        IEnumerable<OfficesProfessional> officeProfessional)
    {
        ArgumentNullException.ThrowIfNull(office);
        ArgumentNullException.ThrowIfNull(officeProfessional);

        return new GetOfficeProfessionalsResponse
        {
            Professionals = [.. officeProfessional.Select(x => new OfficeProfessionalData(x))]
        };
    }
}

public class OfficeProfessionalData(OfficesProfessional officeProfessional)
{
    [UsedImplicitly] public Guid Id { get; private set; } = officeProfessional.Id;
    [UsedImplicitly] public Guid ProfessionalId { get; private set; } = officeProfessional.ProfessionalId;
    [UsedImplicitly] public bool IsPublic { get; private set; } = officeProfessional.IsPublic;
    [UsedImplicitly] public bool IsActive { get; private set; } = officeProfessional.IsActive;
    [UsedImplicitly] public ProfessionalData? Professional { get; private set; } = new(officeProfessional.Professional);
}

public class ProfessionalData(Professional professional)
{
    [UsedImplicitly] public Guid Id { get; private set; } = professional.Id;
    [UsedImplicitly] public string Name { get; private set; } = professional.Name ?? string.Empty;
    [UsedImplicitly] public string PreferredName { get; private set; } = professional.PreferredName ?? string.Empty;
    [UsedImplicitly] public string Email { get; private set; } = professional.Email ?? string.Empty;
    [UsedImplicitly] public string Cpf { get; private set; } = professional.Cpf.Value;
    [UsedImplicitly] public string? Cnpj { get; private set; } = professional.Cnpj?.Value;
    [UsedImplicitly] public string? Website { get; private set; } = professional.Website?.Value;
    [UsedImplicitly] public string? Instagram { get; private set; } = professional.Instagram?.Value;
    [UsedImplicitly] public string? Biography { get; private set; } = professional.Biography?.Value;
    [UsedImplicitly] public bool IsRegistered { get; private set; } = professional.IsRegistered;
    [UsedImplicitly] public string RegisterStatus { get; private set; } = professional.RegisterStatus.StatusTypeName;

    [UsedImplicitly]
    public IEnumerable<ProfessionalSpecialtyDetailData> SpecialtyDetails { get; private set; }
        = professional.SpecialtyDetails.Select(specialityDetail => new ProfessionalSpecialtyDetailData(specialityDetail));

    [UsedImplicitly]
    public IEnumerable<ProfessionalDocumentData> Documents { get; private set; }
        = professional.Documents.Select(document => new ProfessionalDocumentData(document));
}

public class ProfessionalSpecialtyDetailData(ProfessionalSpecialtyDetail specialtyDetail)
{
    [UsedImplicitly] public Guid ProfessionId { get; set; } = specialtyDetail.ProfessionId;
    [UsedImplicitly] public string ProfessionName { get; set; } = specialtyDetail.Profession.Name;
    [UsedImplicitly] public Guid SpecialityId { get; set; } = specialtyDetail.SpecialityId;
    [UsedImplicitly] public string SpecialityName { get; set; } = specialtyDetail.Speciality.Name;
    [UsedImplicitly] public Guid? SubspecialityId { get; set; } = specialtyDetail.SubSpecialityId;
    [UsedImplicitly] public string? SubspecialityName { get; set; } = specialtyDetail.SubSpeciality?.Name;
    [UsedImplicitly] public string? VideoPresentation { get; set; } = specialtyDetail.VideoPresentation;
}

public class ProfessionalDocumentData(ProfessionalDocument document)
{
    [UsedImplicitly] public Guid Id { get; set; } = document.Id;
    [UsedImplicitly] public string DocumentType { get; set; } = document.DocumentType;
    [UsedImplicitly] public string DocumentNumber { get; set; } = document.DocumentNumber;
    [UsedImplicitly] public string DocumentState { get; set; } = document.DocumentState;
    [UsedImplicitly] public string? FrontUrl { get; set; } = document.FrontUrl;
    [UsedImplicitly] public string? BackUrl { get; set; } = document.BackUrl;
    [UsedImplicitly] public bool Validated { get; set; } = document.Validated;
    [UsedImplicitly] public DateTime CreatedAt { get; set; } = document.CreatedAt;
    [UsedImplicitly] public DateTime? RemovedAt { get; set; } = document.RemovedAt;
} 