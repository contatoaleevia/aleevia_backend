namespace Application.DTOs.Offices.GetOfficeDTOs;

public record OfficeResponse
{
    public required OfficeData Office { get; init; }

    public static OfficeResponse FromOffice(Domain.Entities.Offices.Office office, IEnumerable<Domain.Entities.Offices.OfficeAddress> addresses)
    {
        ArgumentNullException.ThrowIfNull(office);
        ArgumentNullException.ThrowIfNull(addresses);

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
    public required IReadOnlyList<OfficeAddressResponse> Addresses { get; init; }
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