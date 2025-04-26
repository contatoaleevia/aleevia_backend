using CrossCutting.Utils;
using Domain.Exceptions;

namespace Domain.Utils.ValueObjects;

public class Email
{
    public string Value { get; set; }

    public Email(string value)
    {
        Value = SetValue(value);
    }

    private string SetValue(string value)
    {
        if(!EmailValidator.IsValid(value))
            throw new EmailInvalidException(value);
        
        return value;
    }
}