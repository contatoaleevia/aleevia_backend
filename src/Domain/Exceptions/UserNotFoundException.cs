namespace Domain.Exceptions;

public class UserNotFoundException(string id)
    : ApiException($"Usuário: {id} não encontrado", 404);