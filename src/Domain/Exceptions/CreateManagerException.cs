namespace Domain.Exceptions;

public class CreateManagerException(Guid userId)
    : ApiException($"An error occured when try create manager for user id: {userId}", 400);
