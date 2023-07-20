using System.Collections.Generic;

public class State : IState
{
    public State()
    {
        BoolProperties = new Dictionary<PropertyId, bool>();
        IntProperties = new Dictionary<PropertyId, int>();
        FloatProperties = new Dictionary<PropertyId, float>();
    }
    
    public State(IState state)
    {
        BoolProperties = new Dictionary<PropertyId, bool>(state.BoolProperties);
        IntProperties = new Dictionary<PropertyId, int>(state.IntProperties);
        FloatProperties = new Dictionary<PropertyId, float>(state.FloatProperties);
    }
    
    IReadOnlyDictionary<PropertyId, bool> IReadOnlyState.BoolProperties => BoolProperties;
    
    IReadOnlyDictionary<PropertyId, int> IReadOnlyState.IntProperties => IntProperties;

    IReadOnlyDictionary<PropertyId, float> IReadOnlyState.FloatProperties => FloatProperties;

    public Dictionary<PropertyId, bool> BoolProperties { get; }
    public Dictionary<PropertyId, int> IntProperties { get; }
    public Dictionary<PropertyId, float> FloatProperties { get; }

    public void Set(PropertyId propertyId, bool value)
    {
        BoolProperties[propertyId] = value;
    }
    
    public void Set(PropertyId propertyId, int value)
    {
        IntProperties[propertyId] = value;
    }
    
    public void Set(PropertyId propertyId, float value)
    {
        FloatProperties[propertyId] = value;
    }

    public IState Clone()
    {
        return new State(this);
    }
}