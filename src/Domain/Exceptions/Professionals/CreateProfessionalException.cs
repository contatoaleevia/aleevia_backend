using Domain.Entities.Identities;

namespace Domain.Exceptions.Professionals;
public class CreateProfessionalException(Guid guid)
    : ApiException($"Ocorreu um erro ao criar o Profissional para o usuário id: {guid}", 400);