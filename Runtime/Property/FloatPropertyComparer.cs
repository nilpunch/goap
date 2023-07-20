using System;

public class FloatPropertyComparer : IPropertyComparer<float>
{
    public int HowHardToEqualize(Property<float> first, Property<float> second)
    {
        return (int)Math.Abs(first.Value - second.Value);
    }
}