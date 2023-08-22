using System;
using Common;

namespace GOAP
{
    public class IntLessEqualThan : IRequirement<IReadOnlyBlackboard>
    {
        private readonly PropertyId _propertyId;
        private readonly int _value;
        private readonly int _multiplier;

        public IntLessEqualThan(PropertyId propertyId, int value, int multiplier = 1)
        {
            _propertyId = propertyId;
            _value = value;
            _multiplier = multiplier;
        }

        public int MismatchCost(IReadOnlyBlackboard state)
        {
            return Math.Max(0, state.Get<int>(_propertyId) - _value) * _multiplier;
        }
    }
}