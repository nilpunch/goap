public class BoolPropertyComparer : IPropertyComparer<bool>
{
    public int HowHardToEqualize(Property<bool> first, Property<bool> second)
    {
        return first.Value == second.Value ? 0 : 1;
    }
}