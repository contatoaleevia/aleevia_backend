using System.Text.Json.Serialization;
using Domain.Entities.Identities;

namespace Application.DTOs.Addresses.CreateAddressDTOs;

public class CreateAddressRequestDto
{
    public Guid SourceId { get; set; }
    public UserType SourceType { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string Neighborhood { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string? Complement { get; set; }
    public string? Type { get; set; }

    [JsonConstructor]
    public CreateAddressRequestDto(Guid sourceId, UserType sourceType, string name, string street, string neighborhood, string number, string city, string state, string zipCode, string? complement, string? type)
    {
        SourceId = sourceId;
        SourceType = sourceType;
        Name = name;
        Street = street;
        Neighborhood = neighborhood;
        Number = number;
        City = city;
        State = state;
        ZipCode = zipCode;
        Complement = complement;
        Type = type;
    }
}