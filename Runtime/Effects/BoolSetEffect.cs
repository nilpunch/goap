﻿using System.Collections.Generic;

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

    public void Modify(IState state)
    {
        state.BoolProperties[_propertyId] = _value;
    }
}