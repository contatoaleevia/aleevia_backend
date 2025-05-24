using System.Text;

namespace Application.Helpers;
public static class RandomGenerator
{
    public static string Generate(int lenght)
    {
        const string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%&*";
        StringBuilder randomString = new();
        Random random = new();

        for (var i = 0; i < lenght; i++)
        {
            var index = random.Next(allowedCharacters.Length);
            randomString.Append(allowedCharacters[index]);
        }
        return randomString.ToString();
    }
}