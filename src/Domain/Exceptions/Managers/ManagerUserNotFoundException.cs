namespace Domain.Exceptions.Managers;

public class ManagerUserNotFoundException(Guid userId)
    : ApiException($"Usuário de id: {userId} não possuí um Administrador associado", 404);
