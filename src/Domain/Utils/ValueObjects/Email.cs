using CrossCutting.Utils;
using Domain.Exceptions;

namespace Domain.Utils.ValueObjects;

public class Email
{
    public string Value { get; set; }

    private Email()
    {
    }

    private Email(string value)
    {
        Value = SetValue(value);
    }

    public static Email Create(string email) => new(email);
    public static Email CreateAsEmpty() => new() { Value = string.Empty };

    private string SetValue(string value)
    {
        if (!EmailValidator.IsValid(value))
            throw new EmailInvalidException(value);

        return value;
    }
}