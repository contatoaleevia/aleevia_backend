using CrossCutting.Utils;
using Domain.Exceptions;

namespace Domain.Utils.ValueObjects;

public class PhoneNumber
{
    public string Value { get; private set; }
    
    private PhoneNumber()
    {
    }
    
    public PhoneNumber(string value)
    {
        Value = SetValue(value);
    }
    
    private string SetValue(string value)
    {
        if(!PhoneNumberValidator.IsValid(value))
            throw new PhoneNumberInvalidException(value);
        
        return value;
    }
}
