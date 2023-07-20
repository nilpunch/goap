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
        var property = state.IntProperties[_propertyId];
        state.IntProperties[_propertyId] = new Property<int>(property.Value + _delta);
    }
}