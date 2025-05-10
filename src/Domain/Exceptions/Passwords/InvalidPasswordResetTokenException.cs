namespace Domain.Exceptions.Passwords;

public class InvalidPasswordResetTokenException(string message = "Token de redefinição de senha inválido ou expirado.") : Exception(message)
{
} 