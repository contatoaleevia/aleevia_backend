using CrossCutting.Utils;
using Domain.Exceptions;
using Domain.Utils;

namespace Domain.Entities.ValueObjects;

public class Document
{
    public string Value { get; private set; }
    private DocumentType Type { get; set; }
    
    private Document(){}

    private Document(string value, DocumentType type)
    {
        Type = type;
        Value = SetValue(value);
    }

    private Document(DocumentType type)
    {
        Type = type;
        Value = string.Empty;
    }
    
    public static Document CreateDocumentAsCnpj(string cnpj) => new(cnpj, DocumentType.Cnpj);
    public static Document CreateAsEmptyCnpj() => new(DocumentType.Cnpj);
    public static Document CreateDocumentAsCpf(string cpf) => new(cpf, DocumentType.Cpf);
    
    private string SetValue(string value)
    {
        value = RemoveSpecialCharacters(value);
        IsValid(value);
        return value;
    }   
    
    private void IsValid(string value)
    {
        if(Type == DocumentType.Cpf && !CpfValidator.IsValid(value))
            throw new CpfNotValidException(value);
        if(Type == DocumentType.Cnpj && !CnpjValidator.IsValid(value))
            throw new CnpjNotValidException(value);
    }

    private static string RemoveSpecialCharacters(string value)
        => value.Replace(".", "").Replace("-", "").Replace("/", "").Trim();

    public string GetFormattedValue()
    {
        return Type switch
        {
            DocumentType.Cpf => CpfValidator.Format(Value),
            DocumentType.Cnpj => CnpjValidator.Format(Value),
            _ => string.Empty
        };
    }
}
