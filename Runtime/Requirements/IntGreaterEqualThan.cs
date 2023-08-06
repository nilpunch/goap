using System;
using Common;

namespace GOAP.Requirements
{
    public class IntGreaterEqualThan : IRequirement
    {
        private readonly PropertyId _propertyId;
        private readonly int _value;
        private readonly int _multiplier;

        public IntGreaterEqualThan(PropertyId propertyId, int value, int multiplier = 1)
        {
            _propertyId = propertyId;
            _value = value;
            _multiplier = multiplier;
        }

        public int MismatchCost(IReadOnlySate sate)
        {
            return Math.Max(0, _value - sate.IntProperties[_propertyId]) * _multiplier;;
        }
    }
}