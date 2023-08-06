using Common;

namespace GOAP.Requirements
{
    public class BoolEqualTo : IRequirement
    {
        private readonly PropertyId _propertyId;
        private readonly bool _value;
        private readonly int _difficulty;

        public BoolEqualTo(PropertyId propertyId, bool value, int difficulty = 1)
        {
            _propertyId = propertyId;
            _value = value;
            _difficulty = difficulty;
        }

        public int MismatchCost(IReadOnlySate sate)
        {
            return sate.BoolProperties[_propertyId] == _value ? 0 : _difficulty;
        }
    }
}