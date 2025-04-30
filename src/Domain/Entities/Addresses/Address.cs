using CrossCutting.Entities;
using Domain.Entities.Identities;

namespace Domain.Entities.Addresses;

public sealed class Address : AggregateRoot
{
    public Guid Id { get; private set; }
    public Guid? SourceId { get; private set; }
    public User? Source { get; private set; }
    public UserType? SourceType { get; private set; }
    public string? Name { get; private set; }
    public string Street { get; private set; }
    public string Neighborhood { get; private set; }
    public string Number { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public string? Complement { get; private set; }
    public string? Type { get; private set; }
    public string Location { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public Address()
    {
    }

    public Address(string street, string city, string state, string zipCode, string number, string neighborhood)
    {
        Id = Guid.NewGuid();
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Number = number;
        Neighborhood = neighborhood;
        // Gerar Latitude e Longitude automaticamente
        Location = string.Empty;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = null;
    }
}