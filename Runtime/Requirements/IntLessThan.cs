public class IntLessThan : IntLessEqualThan
{
    public IntLessThan(PropertyId propertyId, int value, int multiplier = 1) : base(propertyId, value - 1, multiplier)
    {
    }
}