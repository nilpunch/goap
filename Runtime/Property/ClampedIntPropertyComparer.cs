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
    
    public int HowHardToEqualize(Property<int> first, Property<int> second)
    {
        int difference = first.Value - second.Value;

        if (difference < _min || difference > _max)
        {
            return 0;
        }

        return Math.Abs(difference);
    }
}