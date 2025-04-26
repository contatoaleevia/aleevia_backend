using System.Text.RegularExpressions;

namespace CrossCutting.Utils;

public static partial class RegexUtils
{
    [GeneratedRegex("[^0-9]")]
    public static partial Regex NonNumericRegex();
    
    [GeneratedRegex(@"^(\d)\1{10}$")]
    public static partial Regex AllDigitsEqualsRegex();
    
    [GeneratedRegex(@"^\(\d{2}\)\s9\d{4}-\d{4}$")]
    public static partial Regex BrazilianPhoneNumberFormat();
}