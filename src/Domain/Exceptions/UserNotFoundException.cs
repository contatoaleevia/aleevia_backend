namespace Domain.Exceptions;

public class UserNotFoundException(Guid id)
    : ApiException($"User with Id: {id} not found", 404);
public class EmailNotFoundException(string email)
    : ApiException($"User with email: {email} not found", 404);