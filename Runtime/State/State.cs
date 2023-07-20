using System.Collections.Generic;

public class State : IState
{
    public State()
    {
        BoolProperties = new Dictionary<PropertyId, Property<bool>>();
        IntProperties = new Dictionary<PropertyId, Property<int>>();
        FloatProperties = new Dictionary<PropertyId, Property<float>>();
    }
    
    public State(IState state)
    {
        BoolProperties = new Dictionary<PropertyId, Property<bool>>(state.BoolProperties);
        IntProperties = new Dictionary<PropertyId, Property<int>>(state.IntProperties);
        FloatProperties = new Dictionary<PropertyId, Property<float>>(state.FloatProperties);
    }
    
    IReadOnlyDictionary<PropertyId, Property<bool>> IReadOnlyState.BoolProperties => BoolProperties;
    
    IReadOnlyDictionary<PropertyId, Property<int>> IReadOnlyState.IntProperties => IntProperties;

    IReadOnlyDictionary<PropertyId, Property<float>> IReadOnlyState.FloatProperties => FloatProperties;

    public Dictionary<PropertyId, Property<bool>> BoolProperties { get; }
    public Dictionary<PropertyId, Property<int>> IntProperties { get; }
    public Dictionary<PropertyId, Property<float>> FloatProperties { get; }

    public void Set(PropertyId propertyId, bool value)
    {
        BoolProperties[propertyId] = new Property<bool>(value);
    }
    
    public void Set(PropertyId propertyId, int value)
    {
        IntProperties[propertyId] = new Property<int>(value);
    }
    
    public void Set(PropertyId propertyId, float value)
    {
        FloatProperties[propertyId] = new Property<float>(value);
    }

    public IState Clone()
    {
        return new State(this);
    }
}