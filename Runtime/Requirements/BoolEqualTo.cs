using Common;

namespace GOAP
{
    public class BoolEqualTo : IRequirement<IReadOnlyBlackboard>
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

        public int MismatchCost(IReadOnlyBlackboard state)
        {
            return state.Get<bool>(_propertyId) == _value ? 0 : _difficulty;
        }

        public override string ToString()
        {
            return _propertyId + " == " + _value;
        }
    }
}