using System;

public class ClampedIntPropertyComparer : IPropertyComparer<int>
{
    private readonly int _min;
    private readonly int _max;

    public ClampedIntPropertyComparer(int min, int max)
    {
        _min = min;
        _max = max;
    }
    
    public int HowHardToEqualize(int first, int second)
    {
        int difference = first - second;

        if (difference < _min || difference > _max)
        {
            return 0;
        }

        return Math.Abs(difference);
    }
}