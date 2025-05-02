namespace Domain.Entities.ValueObjects;

public class Money
{
    public long ValueAsCents { get; private set; }
    public decimal Value => GetValue(ValueAsCents);

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

    public static Money CreateAsEmpty() => new(0);

    private static decimal GetValue(long cents)
    {
        return decimal.Round(cents / 100m, 2);
    }
} 