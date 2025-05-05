namespace Domain.Exceptions;

public class CreateUserException(Guid userId)
    : ApiException($"Ocorreu um erro ao criar perfil de paciente para o usuário id: {userId}", 400);
