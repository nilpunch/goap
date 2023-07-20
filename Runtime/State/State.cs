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

    public IState Clone()
    {
        return new State(this);
    }
}