namespace Domain.Exceptions;

public class CreateManagerException(Guid userId)
    : ApiException($"Ocorreu um erro ao criar o gerente para o usuário id: {userId}", 400);
