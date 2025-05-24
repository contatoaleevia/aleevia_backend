using JetBrains.Annotations;

namespace Application.DTOs.Addresses.GetAddressBySourceDTOs;

public record GetAddressBySourceResponse(
    Guid Id,
    string? Name,
    string Street,
    string Neighborhood,
    string Number,
    string City,
    string State,
    string ZipCode,
    string? Complement)
{
    [UsedImplicitly] public Guid Id { get; private set; } = Id;
    [UsedImplicitly] public string? Name { get; private set; } = Name;
    [UsedImplicitly] public string Street { get; private set; } = Street;
    [UsedImplicitly] public string Neighborhood { get; private set; } = Neighborhood;
    [UsedImplicitly] public string Number { get; private set; } = Number;
    [UsedImplicitly] public string City { get; private set; } = City;
    [UsedImplicitly] public string State { get; private set; } = State;
    [UsedImplicitly] public string ZipCode { get; private set; } = ZipCode;
    [UsedImplicitly] public string? Complement { get; private set; } = Complement;
}