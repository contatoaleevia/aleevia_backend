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
        IsValid();
    }
    
    public static Document? CreateDocumentAsCnpj(string? cnpj)
        => cnpj is null ? null : new Document(cnpj, DocumentType.Cnpj);
    
    public static Document CreateDocumentAsCpf(string cpf) => new(cpf, DocumentType.Cpf);
    
    private string SetValue(string value)
    {
        return RemoveSpecialCharacters(value);
    }   
    
    private void IsValid()
    {
        if (string.IsNullOrEmpty(Value))
            throw new ArgumentException("Document cannot be null or empty.");

        switch (Type)
        {
            case DocumentType.Cpf when !CpfValidator.IsValid(Value):
                throw new CpfNotValidException(Value);
            case DocumentType.Cnpj when !CnpjValidator.IsValid(Value):
                throw new CnpjNotValidException(Value);
            default:
                throw new ArgumentException("Document type is not valid.");
        }
    }

    private string RemoveSpecialCharacters(string value)
        => value.Replace(".", "").Replace("-", "").Replace("/", "").Trim();
}
