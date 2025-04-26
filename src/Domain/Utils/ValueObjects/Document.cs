using CrossCutting.Utils;
using Domain.Exceptions;

namespace Domain.Utils.ValueObjects;

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
    
    public static Document CreateDocumentAsCnpj(string cnpj) => new(cnpj, DocumentType.Cnpj);
    public static Document CreateDocumentAsCpf(string cpf) => new(cpf, DocumentType.Cpf);
    
    private string SetValue(string value)
    {
        value = RemoveSpecialCharacters(value);
        IsValid(value);
        return value;
    }   
    
    private void IsValid(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Document cannot be null or empty.");

        switch (Type)
        {
            case DocumentType.Cpf when !CpfValidator.IsValid(value):
                throw new CpfNotValidException(value);
            case DocumentType.Cnpj when !CnpjValidator.IsValid(value):
                throw new CnpjNotValidException(value);
            default:
                throw new ArgumentException("Document type is not valid.");
        }
    }

    private string RemoveSpecialCharacters(string value)
        => value.Replace(".", "").Replace("-", "").Replace("/", "").Trim();
}
