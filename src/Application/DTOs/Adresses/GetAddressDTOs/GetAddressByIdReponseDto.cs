using Domain.Entities.Identities;

namespace Application.DTOs.Adresses.GetAddressDTOs;
public class GetAddressByIdReponseDto
{
    public GetAddressByIdReponseDto(
        Guid id, 
        Guid? sourceId, 
        User? source, 
        UserType? sourceType, 
        string? name, 
        string street, 
        string neighborhood, 
        string number, 
        string city, 
        string state, 
        string zipCode, 
        string? complement, 
        string? type, 
        string location, 
        DateTime createdAt, 
        DateTime? updatedAt)
    {
        Id = id;
        SourceId = sourceId;
        Source = source;
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
        Location = location;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Guid Id { get; set; }
    public Guid? SourceId { get; set; }
    public User? Source { get; set; }
    public UserType? SourceType { get; set; }
    public string? Name { get; set; }
    public string Street { get; set; } = null!;
    public string Neighborhood { get; set; } = null!;
    public string Number { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string? Complement { get; set; }
    public string? Type { get; set; }
    public string Location { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}