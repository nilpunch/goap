using System;

public readonly struct PropertyId : IEquatable<PropertyId>
{
    public int Id { get; }

    public bool Equals(PropertyId other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object obj)
    {
        return obj is PropertyId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Id;
    }
}