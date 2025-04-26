namespace Domain.Utils.ValueObjects;

public class Url
{
    public string Value { get; private set; }
    
    public Url(string value)
    {
        Value = value;
    }
}