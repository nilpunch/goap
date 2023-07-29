public class IntDeltaEffect : IEffect
{
    private readonly PropertyId _propertyId;
    private readonly int _delta;

    public IntDeltaEffect(PropertyId propertyId, int delta)
    {
        _propertyId = propertyId;
        _delta = delta;
    }

    public void Modify(IState state)
    {
        state.IntProperties[_propertyId] += _delta;
    }

    public bool IsChangeSomething(IReadOnlySate state)
    {
        return _delta != 0;
    }
}