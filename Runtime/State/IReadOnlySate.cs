using System.Collections.Generic;

public interface IReadOnlySate
{
    IReadOnlyDictionary<PropertyId, bool> BoolProperties { get; }
    IReadOnlyDictionary<PropertyId, int> IntProperties { get; }
    IReadOnlyDictionary<PropertyId, float> FloatProperties { get; }

    IState Clone();
}