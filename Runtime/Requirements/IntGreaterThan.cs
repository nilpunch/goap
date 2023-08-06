using Common;

namespace GOAP
{
    public class IntGreaterThan : IntGreaterEqualThan
    {
        public IntGreaterThan(PropertyId propertyId, int value, int multiplier = 1) : base(propertyId, value + 1, multiplier)
        {
        }
    }
}