using JetBrains.Annotations;

namespace Domain.Entities.ValueObjects;

public class Money
{
    public long ValueAsCents { get; }
    public decimal Value => GetValue(ValueAsCents);

    [UsedImplicitly]
    private Money() { }

    private Money(long valueAsCents)
    {
        ValueAsCents = valueAsCents;
    }

    public static Money Create(decimal value)
    {
        var cents = (long)(value * 100);
        return new Money(cents);
    }

    private static decimal GetValue(long cents)
    {
        return decimal.Round(cents / 100m, 2);
    }
} 