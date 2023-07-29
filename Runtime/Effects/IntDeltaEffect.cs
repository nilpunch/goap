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

    public void Modify(IAssignments assignments)
    {
        if (assignments.IntProperties.ContainsKey(_propertyId))
        {
            assignments.IntProperties[_propertyId] += _delta;
        }
    }

    public void AntiModify(IAssignments assignments)
    {
        if (assignments.IntProperties.ContainsKey(_propertyId))
        {
            assignments.IntProperties[_propertyId] -= _delta;
        }
    }
}