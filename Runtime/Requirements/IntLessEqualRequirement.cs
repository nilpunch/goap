using System;

public class IntLessEqualRequirement : IRequirement
{
    private readonly PropertyId _propertyId;
    private readonly int _lessEqualThenValue;
    private readonly int _multiplier;

    public IntLessEqualRequirement(PropertyId propertyId, int lessEqualThenValue, int multiplier = 1)
    {
        _propertyId = propertyId;
        _lessEqualThenValue = lessEqualThenValue;
        _multiplier = multiplier;
    }

    public int MismatchCost(IReadOnlyState state)
    {
        return Math.Max(0, state.IntProperties[_propertyId] - _lessEqualThenValue) * _multiplier;
    }

    public bool IsSatisfied(IReadOnlyState state)
    {
        return state.IntProperties[_propertyId] <= _lessEqualThenValue;
    }

    public IRequirement GetUnsatisfiedReminder(IReadOnlyState oldState, IReadOnlyState newState)
    {
        var change = newState.IntProperties[_propertyId] - oldState.IntProperties[_propertyId];

        return new IntLessEqualRequirement(_propertyId, _lessEqualThenValue - change, _multiplier);
    }

    public void SatisfyState(IState state)
    {
        if (state.IntProperties.TryGetValue(_propertyId, out var value) && value <= _lessEqualThenValue)
        {
            return;
        }
        state.IntProperties[_propertyId] = _lessEqualThenValue;
    }
}