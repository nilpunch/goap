using System;

public readonly struct Property<TValue>
{
    public Property(TValue value)
    {
        Value = value;
    }
    
    public TValue Value { get; }
}