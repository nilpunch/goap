using System.Collections.Generic;

public class Assignments : IAssignments
{
    public Assignments()
    {
        BoolProperties = new Dictionary<PropertyId, bool>();
        IntProperties = new Dictionary<PropertyId, int>();
        FloatProperties = new Dictionary<PropertyId, float>();
    }
    
    public Assignments(IAssignments assignments)
    {
        BoolProperties = new Dictionary<PropertyId, bool>(assignments.BoolProperties);
        IntProperties = new Dictionary<PropertyId, int>(assignments.IntProperties);
        FloatProperties = new Dictionary<PropertyId, float>(assignments.FloatProperties);
    }
    
    IReadOnlyDictionary<PropertyId, bool> IReadOnlyAssignments.BoolProperties => BoolProperties;
    
    IReadOnlyDictionary<PropertyId, int> IReadOnlyAssignments.IntProperties => IntProperties;

    IReadOnlyDictionary<PropertyId, float> IReadOnlyAssignments.FloatProperties => FloatProperties;

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

    public IAssignments Clone()
    {
        return new Assignments(this);
    }
}