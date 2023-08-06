using Common;

namespace GOAP.Effects
{
    public class BoolSetEffect : IEffect
    {
        private readonly PropertyId _propertyId;
        private readonly bool _value;

        public BoolSetEffect(PropertyId propertyId, bool value)
        {
            _propertyId = propertyId;
            _value = value;
        }

        public void Modify(IState state)
        {
            state.BoolProperties[_propertyId] = _value;
        }

        public bool IsChangeSomething(IReadOnlySate state)
        {
            return state.BoolProperties[_propertyId] != _value;
        }
    }
}