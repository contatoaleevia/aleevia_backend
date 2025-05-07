namespace CrossCutting.Utils;

public static class CnpjValidator
{
    public static bool IsValid(string cnpj)
    {
        if (string.IsNullOrEmpty(cnpj.Trim()))
            return false;

        int[] multiplicador1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] multiplicador2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
        cnpj = cnpj.Trim();

        if (cnpj.Length != 14)
            return false;

        var tempCnpj = cnpj[..12];
        var soma = 0;
        for (var i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

        var resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        var digito = resto.ToString();
        tempCnpj += digito;
        soma = 0;
        for (var i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito += resto;
        return cnpj.EndsWith(digito);
    }

    public static string Format(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        if (value.Length != 14)
            value = value.Replace(".", "").Replace("-", "").Replace("/", "").Trim();

        if (value.Length != 14)
            throw new ArgumentOutOfRangeException("");
        return $"{value[..2]}.{value[2..5]}.{value[5..8]}/{value[8..12]}-{value[12..14]}";
    }
}