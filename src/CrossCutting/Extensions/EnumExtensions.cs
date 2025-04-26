using System.ComponentModel;

namespace CrossCutting.Extensions;

public static class EnumExtensions
{
    public static string TryGetDescription(this Enum? @enum)
    {
        if (@enum == null) return string.Empty;
        try
        {
            var attribute = @enum.GetAttribute<DescriptionAttribute>();
            return attribute.Description;
        }
        catch
        {
            return string.Empty;
        }
    }

    public static IEnumerable<string> TryGetDescriptions<TEnum>(this IEnumerable<TEnum> pEnumerador)
    {
        return pEnumerador.Select(item => TryGetDescription(item as Enum));
    }

    private static TAttribute GetAttribute<TAttribute>(this Enum? value) where TAttribute : Attribute
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "value is null.");

        var type = value.GetType();
        var name = Enum.GetName(type, value);
        return type.GetField(name)
            .GetCustomAttributes(false)
            .OfType<TAttribute>()
            .SingleOrDefault();
    }
}