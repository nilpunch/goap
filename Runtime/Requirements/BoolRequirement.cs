public class BoolRequirement : IRequirement
{
    private readonly PropertyId _propertyId;
    private readonly bool _value;
    private readonly int _difficulty;

    public BoolRequirement(PropertyId propertyId, bool value, int difficulty = 1)
    {
        _propertyId = propertyId;
        _value = value;
        _difficulty = difficulty;
    }

    public int MismatchCost(IReadOnlyAssignments assignments)
    {
        if (assignments.BoolProperties.TryGetValue(_propertyId, out var value))
        {
            return value == _value ? 0 : _difficulty;
        }
        
        return _difficulty;
    }

    public bool IsSatisfied(IReadOnlyAssignments assignments)
    {
        return assignments.BoolProperties.TryGetValue(_propertyId, out var value) && value == _value;
    }

    public bool IsRuined(IReadOnlyAssignments assignments)
    {
        return assignments.BoolProperties.TryGetValue(_propertyId, out var value) && value != _value;
    }

    public IRequirement GetUnsatisfiedReminder(IReadOnlyAssignments oldAssignments, IReadOnlyAssignments newAssignments)
    {
        if (!IsSatisfied(oldAssignments) && IsSatisfied(newAssignments))
        {
            return new SatisfiedRequirement();
        }

        return this;
    }

    public void MakeSatisfactionAssignment(IAssignments assignments)
    {
        assignments.BoolProperties[_propertyId] = _value;
    }
}