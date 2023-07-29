using System.Collections.Generic;

public class BoolSetEffect : IEffect
{
    private readonly PropertyId _propertyId;
    private readonly bool _value;

    public BoolSetEffect(PropertyId propertyId, bool value)
    {
        _propertyId = propertyId;
        _value = value;
    }

    public IEnumerable<PropertyId> AffectedProperties => _propertyId.Yield();

    public void Modify(IAssignments assignments)
    {
        if (assignments.BoolProperties.ContainsKey(_propertyId))
        {
            assignments.BoolProperties[_propertyId] = _value;
        }
    }

    public void AntiModify(IAssignments assignments)
    {
        if (assignments.BoolProperties.ContainsKey(_propertyId))
        {
            assignments.BoolProperties[_propertyId] = !_value;
        }
    }
}