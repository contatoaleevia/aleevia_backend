using Domain.Entities.Addresses;

namespace Application.DTOs.Addresses.CreateAddressDTOs;

public record CreateAddressResponseDto
{
    public required CreateAddressData Address { get; init; }

    public static CreateAddressResponseDto FromAddress(Address address)
    {
        ArgumentNullException.ThrowIfNull(address);

        return new CreateAddressResponseDto
        {
            Address = new CreateAddressData
            {
                Id = address.Id,
                SourceId = address.SourceId,
                SourceType = address.SourceType,
                Name = address.Name,
                Street = address.Street,
                Neighborhood = address.Neighborhood,
                Number = address.Number,
                City = address.City,
                State = address.State,
                ZipCode = address.ZipCode,
                Complement = address.Complement,
                Type = address.Type,
                Location = address.Location,
                CreatedAt = address.CreatedAt,
                UpdatedAt = address.UpdatedAt
            }
        };
    }
}

public record CreateAddressData
{
    public required Guid Id { get; init; }
    public Guid? SourceId { get; init; }
    public Domain.Entities.Identities.UserType? SourceType { get; init; }
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