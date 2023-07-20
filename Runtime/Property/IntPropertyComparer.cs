using System;

public class IntPropertyComparer : IPropertyComparer<int>
{
    public int HowHardToEqualize(int first, int second)
    {
        return Math.Abs(first - second);
    }
}