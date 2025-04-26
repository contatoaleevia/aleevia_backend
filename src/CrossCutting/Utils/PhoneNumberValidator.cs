using System.Text.RegularExpressions;

namespace CrossCutting.Utils;

public static class PhoneNumberValidator
{
    private static readonly Regex BrazilianPhoneRegex = RegexUtils.BrazilianPhoneNumberFormat();
    
    public static bool IsValid(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return false;
            
        if (!BrazilianPhoneRegex.IsMatch(phoneNumber))
            return false;
            
        var areaCode = phoneNumber.Substring(1, 2);

        return areaCode != "00";
    }

}