using System.Collections.Generic;

public interface IReadOnlyAssignments
{
    IReadOnlyDictionary<PropertyId, bool> BoolProperties { get; }
    IReadOnlyDictionary<PropertyId, int> IntProperties { get; }
    IReadOnlyDictionary<PropertyId, float> FloatProperties { get; }

    IAssignments Clone();
}