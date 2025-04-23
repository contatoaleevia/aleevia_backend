namespace Domain.Utils;

public class Document
{
    public string Value { get; private set; }

    public Document(string value)
    {
        Value = value;
    }
}