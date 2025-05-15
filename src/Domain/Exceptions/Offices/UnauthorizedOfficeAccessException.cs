namespace Domain.Exceptions.Offices;

public class UnauthorizedOfficeAccessException : Exception
{
    public UnauthorizedOfficeAccessException(Guid officeId, Guid userId)
        : base($"Usuário {userId} não tem permissão para acessar o local de trabalho {officeId}")
    {
    }
} 