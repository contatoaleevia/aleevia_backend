namespace Domain.Exceptions;

public class UserNotFoundException(Guid id)
    : ApiException($"Usuário com Id: {id} não encontrado", 404);