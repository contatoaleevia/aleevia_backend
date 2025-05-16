using Domain.Entities.Offices;

namespace Application.DTOs.Offices.UpdateOfficeDTOs;

public record UpdateOfficeResponse
{
    public required UpdateOfficeData Office { get; init; }

    public static UpdateOfficeResponse FromOffice(Office office)
    {
        ArgumentNullException.ThrowIfNull(office);

        return new UpdateOfficeResponse
        {
            Office = new UpdateOfficeData
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
                Logo = office.GetLogoUrl(),
                Individual = office.Individual,
                UpdatedAt = DateTime.UtcNow
            }
        };
    }
}

public record UpdateOfficeData
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
    public required DateTime UpdatedAt { get; init; }
} 