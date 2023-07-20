using System.Collections.Generic;

public interface IReadOnlyState
{
    IReadOnlyDictionary<PropertyId, Property<bool>> BoolProperties { get; }
    IReadOnlyDictionary<PropertyId, Property<int>> IntProperties { get; }
    IReadOnlyDictionary<PropertyId, Property<float>> FloatProperties { get; }

    IState Clone();
}