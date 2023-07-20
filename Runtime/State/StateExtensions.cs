﻿public static class StateExtensions
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
    
    public static IState ExceptEqualTo(this IReadOnlyState state, IReadOnlyState from)
    {
        IState result = state.Clone();
        foreach (var property in from.BoolProperties)
        {
            if (state.BoolProperties.TryGetValue(property.Key, out var value) && value == property.Value)
            {
                result.BoolProperties.Remove(property.Key);
            }
        }
        foreach (var property in from.IntProperties)
        {
            if (state.IntProperties.TryGetValue(property.Key, out var value) && value == property.Value)
            {
                result.IntProperties.Remove(property.Key);
            }
        }
        foreach (var property in from.FloatProperties)
        {
            if (state.FloatProperties.TryGetValue(property.Key, out var value) && value == property.Value)
            {
                result.FloatProperties.Remove(property.Key);
            }
        }
        return result;
    }
}