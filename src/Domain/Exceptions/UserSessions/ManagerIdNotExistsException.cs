namespace Domain.Exceptions.UserSessions;

public class ManagerIdNotExistsException() 
    : ApiException("Perfil administrador não encontrado", 400);
