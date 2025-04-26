namespace CrossCutting.Utils;

public static class CnpjValidator
{
    public static bool IsValid(string cnpj)
    {
        if (cnpj.Length != 14)
            return false;
            
        if (RegexUtils.AllDigitsEqualsRegex().IsMatch(cnpj))
            return false;
            
        // Calculate verification digits
        int[] multiplier1 = [5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] multiplier2 = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];
        
        var tempCnpj = cnpj[..12];
        var sum = 0;
        
        for (var i = 0; i < 12; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];
            
        var remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;
        
        var digit = remainder.ToString();
        tempCnpj += digit;
        
        sum = 0;
        for (var i = 0; i < 13; i++)
            sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];
            
        remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;
        
        digit += remainder.ToString();
        
        return cnpj.EndsWith(digit);
    }
}