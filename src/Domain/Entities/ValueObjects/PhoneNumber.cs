using CrossCutting.Utils;
using Domain.Exceptions;

namespace Domain.Entities.ValueObjects;

public class PhoneNumber
{
    public string Value { get; private set; }

    private PhoneNumber()
    {
    }

    private PhoneNumber(string value)
    {
        Value = SetValue(value);
    }

    public static PhoneNumber Create(string phoneNumber) => new(phoneNumber);
    public static PhoneNumber CreateAsEmpty() => new() { Value = string.Empty };

    private string SetValue(string value)
    {
        if (!PhoneNumberValidator.IsValid(value))
            throw new PhoneNumberInvalidException(value);

        return value;
    }
}