
namespace CrossCutting.Utils;

public static class EmailValidator
{
    public static bool IsValid(string email)
    {
        return !string.IsNullOrWhiteSpace(email) && RegexUtils.EmailRegex().IsMatch(email);
    }
}