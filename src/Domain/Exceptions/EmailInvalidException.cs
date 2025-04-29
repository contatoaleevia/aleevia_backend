namespace Domain.Exceptions;

public class EmailInvalidException(string value)
    : ApiException($"Email: {value} is invalid", 400);
