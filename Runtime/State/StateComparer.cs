using System.Collections.Generic;
using System.Linq;

public class StateComparer : IStateComparer
{
    private readonly Dictionary<PropertyId, IPropertyComparer<bool>> _boolComparers = new Dictionary<PropertyId, IPropertyComparer<bool>>();
    private readonly Dictionary<PropertyId, IPropertyComparer<int>> _intComparers = new Dictionary<PropertyId, IPropertyComparer<int>>();
    private readonly Dictionary<PropertyId, IPropertyComparer<float>> _floatComparers = new Dictionary<PropertyId, IPropertyComparer<float>>();

    private readonly IPropertyComparer<bool> _defaultBoolComparer = new BoolPropertyComparer();
    private readonly IPropertyComparer<int> _defaultIntComparer = new IntPropertyComparer();
    private readonly IPropertyComparer<float> _defaultFloatComparer = new FloatPropertyComparer();

    public void AddSpecialComparer(PropertyId propertyId, IPropertyComparer<bool> comparer)
    {
        _boolComparers.Add(propertyId, comparer);
    }
    
    public void AddSpecialComparer(PropertyId propertyId, IPropertyComparer<int> comparer)
    {
        _intComparers.Add(propertyId, comparer);
    }
    
    public void AddSpecialComparer(PropertyId propertyId, IPropertyComparer<float> comparer)
    {
        _floatComparers.Add(propertyId, comparer);
    }
    
    public int HowHardToEqualize(IReadOnlyState first, IReadOnlyState second)
    {
        int cost = 0;
        
        foreach (var propertyId in first.BoolProperties.Keys.Where(propertyId => second.BoolProperties.ContainsKey(propertyId)))
        {
            if (!_boolComparers.TryGetValue(propertyId, out var comparer))
            {
                comparer = _defaultBoolComparer;
            }
            cost += comparer.HowHardToEqualize(first.BoolProperties[propertyId], second.BoolProperties[propertyId]);
        }
        
        foreach (var propertyId in first.IntProperties.Keys.Where(propertyId => second.IntProperties.ContainsKey(propertyId)))
        {
            if (!_intComparers.TryGetValue(propertyId, out var comparer))
            {
                comparer = _defaultIntComparer;
            }
            cost += comparer.HowHardToEqualize(first.IntProperties[propertyId], second.IntProperties[propertyId]);
        }
        
        foreach (var propertyId in first.FloatProperties.Keys.Where(propertyId => second.FloatProperties.ContainsKey(propertyId)))
        {
            if (!_floatComparers.TryGetValue(propertyId, out var comparer))
            {
                comparer = _defaultFloatComparer;
            }
            cost += comparer.HowHardToEqualize(first.FloatProperties[propertyId], second.FloatProperties[propertyId]);
        }

        return cost;
    }
}