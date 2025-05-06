namespace Domain.Exceptions.Authentications;

public class InvalidCredentialsException()
    : ApiException("Credenciais inválidas", 401);