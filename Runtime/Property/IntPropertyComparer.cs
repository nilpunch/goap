using System;

public class IntPropertyComparer : IPropertyComparer<int>
{
    public int Difference(int first, int second)
    {
        return Math.Abs(first - second);
    }
}