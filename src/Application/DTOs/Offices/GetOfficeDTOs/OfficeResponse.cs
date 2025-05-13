using Domain.Entities.Professionals;

namespace Application.DTOs.Offices.GetOfficeDTOs;

public record OfficeResponse
{
    public required OfficeData Office { get; init; }

    public static OfficeResponse FromOffice(
        Domain.Entities.Offices.Office office, 
        IEnumerable<Domain.Entities.Offices.OfficeAddress> addresses,
        IEnumerable<Domain.Entities.Offices.OfficesProfessional> professionals,
        IEnumerable<Domain.Entities.Offices.OfficeSpecialty> specialties)
    {
        ArgumentNullException.ThrowIfNull(office);
        ArgumentNullException.ThrowIfNull(addresses);
        ArgumentNullException.ThrowIfNull(professionals);
        ArgumentNullException.ThrowIfNull(specialties);

        return new OfficeResponse
        {
            Office = new OfficeData
            {
                Id = office.Id,
                OwnerId = office.OwnerId,
                Name = office.Name,
                Cnpj = office.Cnpj.Value,
                Phone = office.Phone.Value,
                Whatsapp = office.Whatsapp.Value,
                Email = office.Email.Value,
                Site = office.Site.Value,
                Instagram = office.Instagram.Value,
                Logo = office.Logo.Value,
                Individual = office.Individual,
                Addresses = [.. addresses.Select(a => new OfficeAddressResponse
                {
                    Id = a.Id,
                    AddressId = a.AddressId,
                    IsTeleconsultation = a.IsTeleconsultation,
                    IsActive = a.IsActive,
                    Address = a.Address == null ? null : new AddressResponse
                    {
                        Id = a.Address.Id,
                        SourceId = a.Address.SourceId,
                        Name = a.Address.Name,
                        Street = a.Address.Street,
                        Neighborhood = a.Address.Neighborhood,
                        Number = a.Address.Number,
                        City = a.Address.City,
                        State = a.Address.State,
                        ZipCode = a.Address.ZipCode,
                        Complement = a.Address.Complement,
                        Type = a.Address.Type,
                        Location = a.Address.Location,
                        CreatedAt = a.Address.CreatedAt,
                        UpdatedAt = a.Address.UpdatedAt
                    }
                })],
                Professionals = [.. professionals.Select(p => new OfficeProfessionalResponse
                {
                    Id = p.Id,
                    ProfessionalId = p.ProfessionalId,
                    IsPublic = p.IsPublic,
                    IsActive = p.IsActive,
                    Professional = p.Professional == null ? null : new ProfessionalResponse
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
                        SpecialtyDetails = [.. p.Professional.SpecialtyDetails.Select(s => new ProfessionalSpecialtyDetailResponse
                        {
                            SpecialityName = s.Speciality.Name,
                            ProfessionName = s.Profession.Name,
                            SubspecialityName = s.Subspeciality?.Name,
                            VideoPresentation = s.VideoPresentation
                        })],
                        Documents = [.. p.Professional.Documents.Select(d => new ProfessionalDocumentResponse
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
                })],
                Specialties = [.. specialties.Select(s => new OfficeSpecialtyResponse
                {
                    Id = s.Id,
                    SpecialtyId = s.SpecialtyId,
                    Name = s.Specialty?.Name ?? string.Empty
                })]
            }
        };
    }
}

public record OfficeData
{
    public required Guid Id { get; init; }
    public required Guid OwnerId { get; init; }
    public required string Name { get; init; }
    public required string Cnpj { get; init; }
    public required string Phone { get; init; }
    public required string Whatsapp { get; init; }
    public required string Email { get; init; }
    public required string Site { get; init; }
    public required string Instagram { get; init; }
    public required string Logo { get; init; }
    public required bool Individual { get; init; }
    public required IReadOnlyList<OfficeAddressResponse> Addresses { get; init; }
    public required IReadOnlyList<OfficeProfessionalResponse> Professionals { get; init; }
    public required IReadOnlyList<OfficeSpecialtyResponse> Specialties { get; init; }
}

public record OfficeAddressResponse
{
    public required Guid Id { get; init; }
    public Guid? AddressId { get; init; }
    public required bool IsTeleconsultation { get; init; }
    public required bool IsActive { get; init; }
    public AddressResponse? Address { get; init; }
}

public record AddressResponse
{
    public required Guid Id { get; init; }
    public Guid? SourceId { get; init; }
    public string? Name { get; init; }
    public required string Street { get; init; }
    public required string Neighborhood { get; init; }
    public required string Number { get; init; }
    public required string City { get; init; }
    public required string State { get; init; }
    public required string ZipCode { get; init; }
    public string? Complement { get; init; }
    public string? Type { get; init; }
    public required string Location { get; init; }
    public required DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}

public record OfficeProfessionalResponse
{
    public required Guid Id { get; init; }
    public required Guid ProfessionalId { get; init; }
    public required bool IsPublic { get; init; }
    public required bool IsActive { get; init; }
    public ProfessionalResponse? Professional { get; init; }
}

public record ProfessionalResponse
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
    public required IReadOnlyList<ProfessionalSpecialtyDetailResponse> SpecialtyDetails { get; init; }
    public required IReadOnlyList<ProfessionalDocumentResponse> Documents { get; init; }
}

public record ProfessionalSpecialtyDetailResponse
{
    public required string SpecialityName { get; init; }
    public required string ProfessionName { get; init; }
    public string? SubspecialityName { get; init; }
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
    public required DateTime CreatedAt { get; init; }
    public DateTime? RemovedAt { get; init; }
}

public record ProfessionResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required bool Active { get; init; }
}

public record SpecialtyResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required bool Active { get; init; }
}

public record SubspecialtyResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required bool Active { get; init; }
}

public record OfficeSpecialtyResponse
{
    public required Guid Id { get; init; }
    public required Guid SpecialtyId { get; init; }
    public required string Name { get; init; }
} 