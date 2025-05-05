using System.Text;

namespace Application.Helpers;
public class RandomGenerator
{
    public static string Generate(int lenght)
    {
        const string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%&*";
        StringBuilder randomString = new();
        Random random = new();

        for (int i = 0; i < lenght; i++)
        {
            int index = random.Next(allowedCharacters.Length);
            randomString.Append(allowedCharacters[index]);
        }
        return randomString.ToString();
    }
}