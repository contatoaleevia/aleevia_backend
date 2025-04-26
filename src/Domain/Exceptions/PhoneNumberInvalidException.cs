namespace Domain.Exceptions;

public class PhoneNumberInvalidException(string phoneNumber)
    : ApiException($"Phone number: {phoneNumber} is invalid", 400);