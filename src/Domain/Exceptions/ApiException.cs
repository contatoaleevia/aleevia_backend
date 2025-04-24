namespace Domain.Exceptions;

public abstract class ApiException(string message, int statusCode) : Exception
{
    public override string Message { get; } = message;
    public int StatusCode { get; } = statusCode;
}
