public static class StateExtensions
{
    public static void ApplyProperties(this IAssignments assignments, IReadOnlyAssignments from)
    {
        foreach (var property in from.BoolProperties)
        {
            assignments.BoolProperties[property.Key] = property.Value;
        }
        foreach (var property in from.IntProperties)
        {
            assignments.IntProperties[property.Key] = property.Value;
        }
        foreach (var property in from.FloatProperties)
        {
            assignments.FloatProperties[property.Key] = property.Value;
        }
    }
    
    public static IAssignments ExceptEqualTo(this IReadOnlyAssignments assignments, IReadOnlyAssignments from)
    {
        IAssignments result = assignments.Clone();
        foreach (var property in from.BoolProperties)
        {
            if (assignments.BoolProperties.TryGetValue(property.Key, out var value) && value == property.Value)
            {
                result.BoolProperties.Remove(property.Key);
            }
        }
        foreach (var property in from.IntProperties)
        {
            if (assignments.IntProperties.TryGetValue(property.Key, out var value) && value == property.Value)
            {
                result.IntProperties.Remove(property.Key);
            }
        }
        foreach (var property in from.FloatProperties)
        {
            if (assignments.FloatProperties.TryGetValue(property.Key, out var value) && value == property.Value)
            {
                result.FloatProperties.Remove(property.Key);
            }
        }
        return result;
    }
}