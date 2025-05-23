﻿namespace Domain.Entities.ValueObjects;

public class Url
{
    public string Value { get; private set; } = string.Empty;

    private Url()
    {
    }

    private Url(string value)
    {
        Value = value;
    }
    
    public static Url Create(string url) => new(url);
    public static Url CreateAsEmpty() => new() { Value = string.Empty };
}