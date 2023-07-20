using System;

public readonly struct PropertyId : IEquatable<PropertyId>
{
    public PropertyId(int id, string name = "")
    {
        Id = id;
        Name = name;
    }

    public static PropertyId Unique(string name = "")
    {
        return new PropertyId(Guid.NewGuid().GetHashCode(), name);
    }

    public int Id { get; }
    
    public string Name { get; }

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

    public override string ToString()
    {
        return Name;
    }
}