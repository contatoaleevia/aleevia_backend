using System.Text.Json.Serialization;

namespace Application.DTOs.Addresses.UpdateAddressDTOs;

[method: JsonConstructor]
public class UpdateAddressRequestDto(
    Guid id,
    string? name,
    string? street,
    string? neighborhood,
    string? number,
    string? city,
    string? state,
    string? zipCode,
    string? complement)
{
    public Guid Id { get; set; } = id;
    public string? Name { get; set; } = name;
    public string? Street { get; set; } = street;
    public string? Neighborhood { get; set; } = neighborhood;
    public string? Number { get; set; } = number;
    public string? City { get; set; } = city;
    public string? State { get; set; } = state;
    public string? ZipCode { get; set; } = zipCode;
    public string? Complement { get; set; } = complement;
} 