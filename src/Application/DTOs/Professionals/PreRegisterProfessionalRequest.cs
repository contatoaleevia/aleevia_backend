using System.Text.Json.Serialization;

namespace Application.DTOs.Professionals;

[method:JsonConstructor]
public record PreRegisterProfessionalRequest(
    string Cpf,
    string Name,
    string Email
);