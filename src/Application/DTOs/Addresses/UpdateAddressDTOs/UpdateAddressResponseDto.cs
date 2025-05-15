namespace Application.DTOs.Addresses.UpdateAddressDTOs;

public record UpdateAddressResponseDto
{
    public required UpdateAddressData Address { get; init; }

    public static UpdateAddressResponseDto FromAddress(Domain.Entities.Addresses.Address address)
    {
        ArgumentNullException.ThrowIfNull(address);

        return new UpdateAddressResponseDto
        {
            Address = new UpdateAddressData
            {
                Id = address.Id,
                Name = address.Name,
                Street = address.Street,
                Neighborhood = address.Neighborhood,
                Number = address.Number,
                City = address.City,
                State = address.State,
                ZipCode = address.ZipCode,
                Complement = address.Complement,
                UpdatedAt = address.UpdatedAt
            }
        };
    }
}

public record UpdateAddressData
{
    public required Guid Id { get; init; }
    public string? Name { get; init; }
    public required string Street { get; init; }
    public required string Neighborhood { get; init; }
    public required string Number { get; init; }
    public required string City { get; init; }
    public required string State { get; init; }
    public required string ZipCode { get; init; }
    public string? Complement { get; init; }
    public DateTime? UpdatedAt { get; init; }
} 