using System.Text.Json.Serialization;
using Domain.Contracts.Services.RegisterProfessionals;

namespace Application.DTOs.Professionals.UpdateProfessionalRequestDTOs;

[method:JsonConstructor]
public record UpdateProfessionalRequest(
    string Name,
    string PreferredName,
    string Email,
    string Website,
    string Instagram,
    string Biography,
    ProfessionalProfessionRequest ProfessionData,
    string VideoPresentation,
    Guid AddressId
);