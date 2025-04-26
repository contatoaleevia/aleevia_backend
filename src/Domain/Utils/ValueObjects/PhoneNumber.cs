namespace Domain.Utils.ValueObjects;

public class PhoneNumber(string value)
{
    public string Value { get; private set; } = value;
}
