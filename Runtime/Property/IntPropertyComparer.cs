using System;

public class IntPropertyComparer : IPropertyComparer<int>
{
    public int HowHardToEqualize(Property<int> first, Property<int> second)
    {
        return Math.Abs(first.Value - second.Value);
    }
}