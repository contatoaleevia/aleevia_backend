namespace Domain.Exceptions.Passwords;

public class PasswordResetFailedException(string message = "Falha ao redefinir a senha. Verifique se o token é válido e se a nova senha atende aos requisitos.") : Exception(message); 