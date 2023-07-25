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

    public int MismatchCost(IReadOnlyState state)
    {
        return state.BoolProperties[_propertyId] == _value ? 0 : _difficulty;
    }

    public bool IsSatisfied(IReadOnlyState state)
    {
        return state.BoolProperties[_propertyId] == _value;
    }

    public IRequirement GetUnsatisfiedReminder(IReadOnlyState oldState, IReadOnlyState newState)
    {
        if (!IsSatisfied(oldState) && IsSatisfied(newState))
        {
            return new SatisfiedRequirement();
        }

        return this;
    }

    public void SatisfyState(IState state)
    {
        state.BoolProperties[_propertyId] = _value;
    }
}