using System.Text.Json.Serialization;
using Domain.Entities.Identities;

namespace Application.DTOs.Addresses.CreateAddressDTOs;

[method: JsonConstructor]
public class CreateAddressRequestDto(Guid sourceId, UserType sourceType, string name, string street, string neighborhood, string number, string city, string state, string zipCode, string? complement, string? type)
{
    public Guid SourceId { get; set; } = sourceId;
    public UserType SourceType { get; set; } = sourceType;
    public string Name { get; set; } = name;
    public string Street { get; set; } = street;
    public string Neighborhood { get; set; } = neighborhood;
    public string Number { get; set; } = number;
    public string City { get; set; } = city;
    public string State { get; set; } = state;
    public string ZipCode { get; set; } = zipCode;
    public string? Complement { get; set; } = complement;
    public string? Type { get; set; } = type;
}