using Domain.Entities.Offices;

namespace Application.DTOs.Offices.GetOfficeDTOs;

public record OfficeSimplifiedResponse
{
    public required OfficeSimplifiedData Office { get; init; }

    public static OfficeSimplifiedResponse FromOffice(
        Office office, 
        IEnumerable<OfficeAddress> addresses,
        IEnumerable<OfficeSpecialty> specialties)
    {
        ArgumentNullException.ThrowIfNull(office);
        ArgumentNullException.ThrowIfNull(addresses);
        ArgumentNullException.ThrowIfNull(specialties);

        return new OfficeSimplifiedResponse
        {
            Office = new OfficeSimplifiedData
            {
                Id = office.Id,
                OwnerId = office.OwnerId,
                Name = office.Name,
                Cnpj = office.Cnpj.Value,
                PhoneNumber = office.Phone.Value,
                Whatsapp = office.Whatsapp.Value,
                Email = office.Email.Value,
                Site = office.Site.Value,
                Instagram = office.Instagram.Value,
                Logo = office.Logo.Url,
                Individual = office.Individual,
                Addresses = [.. addresses.Select(a => new OfficeAddressResponse
                {
                    Id = a.Id,
                    AddressId = a.AddressId,
                    IsTeleconsultation = a.IsTeleconsultation,
                    IsActive = a.IsActive,
                    Address = new AddressResponse
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
                Specialties = [.. specialties.Select(s => new OfficeSpecialtyResponse
                {
                    Id = s.Id,
                    SpecialtyId = s.SpecialtyId,
                    Name = s.Speciality.Name
                })]
            }
        };
    }
}

public record OfficeSimplifiedData
{
    public required Guid Id { get; init; }
    public required Guid OwnerId { get; init; }
    public required string Name { get; init; }
    public required string Cnpj { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Whatsapp { get; init; }
    public required string Email { get; init; }
    public required string Site { get; init; }
    public required string Instagram { get; init; }
    public required string Logo { get; init; }
    public required bool Individual { get; init; }
    public required IReadOnlyList<OfficeAddressResponse> Addresses { get; init; }
    public required IReadOnlyList<OfficeSpecialtyResponse> Specialties { get; init; }
} 