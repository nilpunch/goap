using System;

public readonly struct PropertyId : IEquatable<PropertyId>
{
    public PropertyId(Guid id)
    {
        Id = id;
    }

    public static PropertyId Unique()
    {
        return new PropertyId(Guid.NewGuid());
    }

    public Guid Id { get; }

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
        return Id.GetHashCode();
    }
}