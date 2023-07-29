using System;

public class IntGreaterEqualRequirement : IRequirement
{
    private readonly PropertyId _propertyId;
    private readonly int _greaterEqualThenValue;
    private readonly int _multiplier;
    private readonly int _allowedDifference;

    public IntGreaterEqualRequirement(PropertyId propertyId, int greaterEqualThenValue, int multiplier = 1, int allowedDifference = 100)
    {
        _propertyId = propertyId;
        _greaterEqualThenValue = greaterEqualThenValue;
        _multiplier = multiplier;
        _allowedDifference = allowedDifference;
    }

    public int MismatchCost(IReadOnlyAssignments assignments)
    {
        if (assignments.IntProperties.TryGetValue(_propertyId, out var value))
        {
            return Math.Max(0, _greaterEqualThenValue - value) * _multiplier;
        }

        return _allowedDifference * _multiplier;
    }

    public bool IsSatisfied(IReadOnlyAssignments assignments)
    {
        return assignments.IntProperties.TryGetValue(_propertyId, out var value) && value >= _greaterEqualThenValue;
    }

    public bool IsRuined(IReadOnlyAssignments assignments)
    {
        return assignments.IntProperties.TryGetValue(_propertyId, out var value) && value + _allowedDifference < _greaterEqualThenValue;
    }

    public IRequirement GetUnsatisfiedReminder(IReadOnlyAssignments oldAssignments, IReadOnlyAssignments newAssignments)
    {
        var change = newAssignments.IntProperties[_propertyId] - oldAssignments.IntProperties[_propertyId];

        return new IntGreaterEqualRequirement(_propertyId, _greaterEqualThenValue - change, _multiplier);
    }

    public void MakeSatisfactionAssignment(IAssignments assignments)
    {
        if (assignments.IntProperties.TryGetValue(_propertyId, out var value) && value >= _greaterEqualThenValue)
        {
            return;
        }
        assignments.IntProperties[_propertyId] = _greaterEqualThenValue;
    }
}