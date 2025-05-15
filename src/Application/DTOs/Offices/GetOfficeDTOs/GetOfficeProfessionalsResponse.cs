using Domain.Entities.Offices;
using Domain.Entities.Professionals;

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
    public Guid Id { get; private set; } = officeProfessional.Id;
    public Guid ProfessionalId { get; private set; } = officeProfessional.ProfessionalId;
    public bool IsPublic { get; private set; } = officeProfessional.IsPublic;
    public bool IsActive { get; private set; } = officeProfessional.IsActive;
    public ProfessionalData? Professional { get; private set; } = new(officeProfessional.Professional);
}

public class ProfessionalData(Professional professional)
{
    public Guid Id { get; private set; } = professional.Id;
    public string Name { get; private set; } = professional.Name ?? string.Empty;
    public string PreferredName { get; private set; } = professional.PreferredName ?? string.Empty;
    public string Email { get; private set; } = professional.Email ?? string.Empty;
    public string Cpf { get; private set; } = professional.Cpf.Value;
    public string? Cnpj { get; private set; } = professional.Cnpj?.Value;
    public string? Website { get; private set; } = professional.Website?.Value;
    public string? Instagram { get; private set; } = professional.Instagram?.Value;
    public string? Biography { get; private set; } = professional.Biography?.Value;
    public bool IsRegistered { get; private set; } = professional.IsRegistered;
    public string RegisterStatus { get; private set; } = professional.RegisterStatus.StatusTypeName;

    public IEnumerable<ProfessionalSpecialtyDetailData> SpecialtyDetails { get; private set; }
        = professional.SpecialtyDetails.Select(specialityDetail => new ProfessionalSpecialtyDetailData(specialityDetail));

    public IEnumerable<ProfessionalDocumentData> Documents { get; private set; }
        = professional.Documents.Select(document => new ProfessionalDocumentData(document));
}

public class ProfessionalSpecialtyDetailData(ProfessionalSpecialtyDetail specialtyDetail)
{
    public Guid ProfessionId { get; set; } = specialtyDetail.ProfessionId;
    public string ProfessionName { get; set; } = specialtyDetail.Profession.Name;
    public Guid SpecialityId { get; set; } = specialtyDetail.SpecialityId;
    public string SpecialityName { get; set; } = specialtyDetail.Speciality.Name;
    public Guid? SubspecialityId { get; set; } = specialtyDetail.SubspecialityId;
    public string? SubspecialityName { get; set; } = specialtyDetail.Subspeciality?.Name;
    public string? VideoPresentation { get; set; } = specialtyDetail.VideoPresentation;
}

public class ProfessionalDocumentData(ProfessionalDocument document)
{
    public Guid Id { get; set; } = document.Id;
    public string DocumentType { get; set; } = document.DocumentType;
    public string DocumentNumber { get; set; } = document.DocumentNumber;
    public string DocumentState { get; set; } = document.DocumentState;
    public string? FrontUrl { get; set; } = document.FrontUrl;
    public string? BackUrl { get; set; } = document.BackUrl;
    public bool Validated { get; set; } = document.Validated;
    public DateTime CreatedAt { get; set; } = document.CreatedAt;
    public DateTime? RemovedAt { get; set; } = document.RemovedAt;
} 