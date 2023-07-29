using System;

public class IntLessEqualRequirement : IRequirement
{
    private readonly PropertyId _propertyId;
    private readonly int _lessEqualThenValue;
    private readonly int _multiplier;
    private readonly int _allowedDifference;

    public IntLessEqualRequirement(PropertyId propertyId, int lessEqualThenValue, int multiplier = 1, int allowedDifference = 100)
    {
        _propertyId = propertyId;
        _lessEqualThenValue = lessEqualThenValue;
        _multiplier = multiplier;
        _allowedDifference = allowedDifference;
    }

    public int MismatchCost(IReadOnlyAssignments assignments)
    {
        if (assignments.IntProperties.TryGetValue(_propertyId, out var value))
        {
            return Math.Max(0, value - _lessEqualThenValue) * _multiplier;
        }

        return _allowedDifference * _multiplier;
    }

    public bool IsSatisfied(IReadOnlyAssignments assignments)
    {
        return assignments.IntProperties.TryGetValue(_propertyId, out var value) && value <= _lessEqualThenValue;
    }

    public bool IsRuined(IReadOnlyAssignments assignments)
    {
        return assignments.IntProperties.TryGetValue(_propertyId, out var value) && value - _allowedDifference > _lessEqualThenValue;
    }

    public IRequirement GetUnsatisfiedReminder(IReadOnlyAssignments oldAssignments, IReadOnlyAssignments newAssignments)
    {
        var change = newAssignments.IntProperties[_propertyId] - oldAssignments.IntProperties[_propertyId];

        return new IntLessEqualRequirement(_propertyId, _lessEqualThenValue - change, _multiplier);
    }

    public void MakeSatisfactionAssignment(IAssignments assignments)
    {
        if (assignments.IntProperties.TryGetValue(_propertyId, out var value) && value <= _lessEqualThenValue)
        {
            return;
        }
        assignments.IntProperties[_propertyId] = _lessEqualThenValue;
    }
}