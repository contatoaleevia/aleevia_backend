using System.ComponentModel;

namespace Domain.Utils;

public enum DocumentType : ushort
{
    [Description("CPF")]
    Cpf = 0,
    [Description("CNPJ")]
    Cnpj = 1
}