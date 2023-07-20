using System.Collections.Generic;

public interface IState : IReadOnlyState
{
    new Dictionary<PropertyId, Property<bool>> BoolProperties { get; }
    new Dictionary<PropertyId, Property<int>> IntProperties { get; }
    new Dictionary<PropertyId, Property<float>> FloatProperties { get; }
}