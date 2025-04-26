namespace Domain.Exceptions;

public class EmailNotFoundException(string email)
    : ApiException($"User with email: {email} not found", 404);