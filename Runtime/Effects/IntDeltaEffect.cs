using System.Collections.Generic;

public class IntDeltaEffect : IEffect
{
    private readonly PropertyId _propertyId;
    private readonly int _delta;

    public IntDeltaEffect(PropertyId propertyId, int delta)
    {
        _propertyId = propertyId;
        _delta = delta;
    }

    public IEnumerable<PropertyId> AffectedProperties => _propertyId.Yield();

    public void Modify(IState state)
    {
        if (state.IntProperties.ContainsKey(_propertyId))
        {
            state.IntProperties[_propertyId] += _delta;
        }
    }

    public void AntiModify(IState state)
    {
        if (state.IntProperties.ContainsKey(_propertyId))
        {
            state.IntProperties[_propertyId] -= _delta;
        }
    }
}