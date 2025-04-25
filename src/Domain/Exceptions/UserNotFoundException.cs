namespace Domain.Exceptions;

public class UserNotFoundException(Guid id)
    : ApiException($"User with Id: {id} not found", 404);