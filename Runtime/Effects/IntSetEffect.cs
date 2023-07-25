using System.Collections.Generic;

// public class IntSetEffect : IEffect
// {
//     private readonly PropertyId _propertyId;
//     private readonly int _value;
//
//     public IntSetEffect(PropertyId propertyId, int value)
//     {
//         _propertyId = propertyId;
//         _value = value;
//     }
//
//     public IEnumerable<PropertyId> AffectedProperties => _propertyId.Yield();
//
//     public void Modify(IState state)
//     {
//         state.IntProperties[_propertyId] = _value;
//     }
// }