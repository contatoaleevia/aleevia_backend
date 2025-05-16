using System.Text;

namespace CrossCutting.Extensions;

public static class StringExtensions
{
    public static string RemoveSpecialCharacters(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        var result = new StringBuilder();
        foreach (var c in value.Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
        {
            result.Append(c);
        }

        return result.ToString();
    }
    
    public static bool IsNullOrEmpty(this string? value)
    {
        return string.IsNullOrEmpty(value);
    }
}