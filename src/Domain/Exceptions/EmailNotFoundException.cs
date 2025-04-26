namespace Domain.Exceptions;

public class EmailNotFoundException(string email)
    : ApiException($"Usuário com email: {email} não encontrado", 404);