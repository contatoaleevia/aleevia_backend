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

    private static TAttribute GetAttribute<TAttribute>(this Enum? value) where TAttribute : Attribute
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "value is null.");

        var type = value.GetType();
        var name = Enum.GetName(type, value);
        if (name == null)
            throw new ArgumentException($"Enum value '{value}' not found in type '{type.Name}'.");

        try
        {
            return type.GetField(name)!
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault()!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new InvalidEnumArgumentException($"Enum value '{value}' does not have an attribute of type '{typeof(TAttribute).Name}'.");
        }
    }

    public static TEnum? GetEnumFromDescription<TEnum>(string description) where TEnum : struct, Enum
    {
        foreach (var field in typeof(TEnum).GetFields())
        {
            var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .Cast<DescriptionAttribute>()
                            .FirstOrDefault();

            if ((attr != null && attr.Description == description) || field.Name == description)
                return (TEnum)(field.GetValue(null) ?? throw new InvalidOperationException("Field value is null."));
        }
        return null;
    }
}