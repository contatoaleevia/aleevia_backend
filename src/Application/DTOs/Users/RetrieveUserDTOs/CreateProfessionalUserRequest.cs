using Domain.Entities.Identities;

namespace Application.DTOs.Users.RetrieveUserDTOs;

public record CreateProfessionalUserRequest(
    string Email,
    string Name,
    string Cpf
);