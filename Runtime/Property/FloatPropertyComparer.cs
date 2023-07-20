using System;

public class FloatPropertyComparer : IPropertyComparer<float>
{
    public int Difference(float first, float second)
    {
        return (int)Math.Abs(first - second);
    }
}