using System.Collections.Generic;

public interface IReadOnlyState
{
    IReadOnlyDictionary<PropertyId, bool> BoolProperties { get; }
    IReadOnlyDictionary<PropertyId, int> IntProperties { get; }
    IReadOnlyDictionary<PropertyId, float> FloatProperties { get; }

    IState Clone();
}