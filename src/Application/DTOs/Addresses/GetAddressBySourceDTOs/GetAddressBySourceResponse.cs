namespace Application.DTOs.Adresses.GetAddressBySourceDTOs;

public record GetAddressBySourceResponse(
    string? Name,
    string Street,
    string Neighborhood,
    string Number,
    string City,
    string State,
    string ZipCode,
    string? Complement)
{
    public string? Name { get; private set; } = Name;
    public string Street { get; private set; } = Street;
    public string Neighborhood { get; private set; } = Neighborhood;
    public string Number { get; private set; } = Number;
    public string City { get; private set; } = City;
    public string State { get; private set; } = State;
    public string ZipCode { get; private set; } = ZipCode;
    public string? Complement { get; private set; } = Complement;
}