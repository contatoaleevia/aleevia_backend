using System.Text.RegularExpressions;

namespace CrossCutting.Utils;

public static partial class RegexUtils
{
    [GeneratedRegex("[^0-9]")]
    public static partial Regex NonNumericRegex();
    
    [GeneratedRegex(@"^(\d)\1{10}$")]
    public static partial Regex AllDigitsEqualsRegex();
    
    [GeneratedRegex(@"^(\(?\d{2}\)?\s?)?(9\d{4}|\d{4})-?\d{4}$")]
    public static partial Regex BrazilianPhoneNumberFormat();
    
    [GeneratedRegex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")]
    public static partial Regex EmailRegex();
}