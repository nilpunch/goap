using System;

public class IntGreaterEqualRequirement : IRequirement
{
    private readonly PropertyId _propertyId;
    private readonly int _greaterEqualThenValue;
    private readonly int _multiplier;

    public IntGreaterEqualRequirement(PropertyId propertyId, int greaterEqualThenValue, int multiplier = 1)
    {
        _propertyId = propertyId;
        _greaterEqualThenValue = greaterEqualThenValue;
        _multiplier = multiplier;
    }

    public int MismatchCost(IReadOnlyState state)
    {
        return Math.Max(0, _greaterEqualThenValue - state.IntProperties[_propertyId]) * _multiplier;
    }

    public bool IsSatisfied(IReadOnlyState state)
    {
        return state.IntProperties[_propertyId] >= _greaterEqualThenValue;
    }

    public IRequirement GetUnsatisfiedReminder(IReadOnlyState oldState, IReadOnlyState newState)
    {
        var change = newState.IntProperties[_propertyId] - oldState.IntProperties[_propertyId];

        return new IntGreaterEqualRequirement(_propertyId, _greaterEqualThenValue - change, _multiplier);
    }

    public void SatisfyState(IState state)
    {
        if (state.IntProperties.TryGetValue(_propertyId, out var value) && value >= _greaterEqualThenValue)
        {
            return;
        }
        state.IntProperties[_propertyId] = _greaterEqualThenValue;
    }
}