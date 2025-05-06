namespace Domain.Exceptions;

public class UserAlreadyExistException()
    : ApiException($"Já existe um usuário com o cpf ou email fornecido", 400);