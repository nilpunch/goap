using System.Collections.Generic;

public interface IState : IReadOnlySate
{
    new Dictionary<PropertyId, bool> BoolProperties { get; }
    new Dictionary<PropertyId, int> IntProperties { get; }
    new Dictionary<PropertyId, float> FloatProperties { get; }
}