public class BoolPropertyComparer : IPropertyComparer<bool>
{
    private readonly int _cost;

    public BoolPropertyComparer(int cost = 1)
    {
        _cost = cost;
    }
    
    public int Difference(bool first, bool second)
    {
        return first == second ? 0 : _cost;
    }
}