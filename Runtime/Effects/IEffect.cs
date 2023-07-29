using System.Collections.Generic;

public interface IEffect
{
    IEnumerable<PropertyId> AffectedProperties { get; }
    void Modify(IAssignments assignments);
    void AntiModify(IAssignments assignments);
}