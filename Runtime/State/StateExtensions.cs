public static class StateExtensions
{
    public static void ApplyProperties(this IState state, IReadOnlyState from)
    {
        foreach (var property in from.BoolProperties)
        {
            state.BoolProperties[property.Key] = property.Value;
        }
        foreach (var property in from.IntProperties)
        {
            state.IntProperties[property.Key] = property.Value;
        }
        foreach (var property in from.FloatProperties)
        {
            state.FloatProperties[property.Key] = property.Value;
        }
    }
}