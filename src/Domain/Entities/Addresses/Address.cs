using CrossCutting.Entities;
using Domain.Entities.Identities;

namespace Domain.Entities.Addresses;

public sealed class Address : AggregateRoot
{
    public Guid? SourceId { get; private set; }
    public User? Source { get; private set; }
    public UserType? SourceType { get; private set; }
    public string? Name { get; private set; }
    public string Street { get; private set; } = string.Empty;
    public string Neighborhood { get; private set; } = string.Empty;
    public string Number { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    public string ZipCode { get; private set; } = string.Empty;
    public string? Complement { get; private set; }
    public string? Type { get; private set; }
    public string Location { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public Address()
    {
    }

    public Address(Guid? sourceId, UserType? sourceType, string? name, string street, string neighborhood,
        string number, string city, string state, string zipCode, string? complement, string? type)
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
        Location = string.Empty;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = null;
    }

    public void Update(string? name, string? street, string? neighborhood, string? number, string? city, string? state, string? zipCode, string? complement)
    {
        Name = name ?? Name;
        Street = street ?? Street;
        Neighborhood = neighborhood ?? Neighborhood;
        Number = number ?? Number;
        City = city ?? City;
        State = state ?? State;
        ZipCode = zipCode ?? ZipCode;
        Complement = complement ?? Complement;
        UpdatedAt = DateTime.UtcNow;
    }
}