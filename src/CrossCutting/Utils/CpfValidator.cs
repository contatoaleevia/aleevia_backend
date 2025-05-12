namespace CrossCutting.Utils;

public static class CpfValidator
{
    public static bool IsValid(string cpf)
    {
        if (string.IsNullOrEmpty(cpf.Trim()))
            return false;

        var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        cpf = cpf.Replace(".", "").Replace("-", "");
        cpf = cpf.Trim();

        if (cpf.Length != 11)
            return false;

        var tempCpf = cpf[..9];
        var soma = 0;
        for (var i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        var resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        var digito = resto.ToString();
        tempCpf += digito;
        soma = 0;
        for (var i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito += resto;
        return cpf.EndsWith(digito);
    }

    public static string Format(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        if (value.Length != 11)
            value = value.Replace(".", "").Replace("-", "").Trim();
        
        if (value.Length != 11)
            throw new ArgumentException("O CPF deve conter 11 dígitos.");
        
        return $"{value[..3]}.{value[3..6]}.{value[6..9]}-{value[9..]}";
    }
}