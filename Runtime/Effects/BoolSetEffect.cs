using Common;

namespace GOAP
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
            state.Set(_propertyId, _value);
        }

        public bool IsChangeSomething(IReadOnlyState state)
        {
            return state.Get<bool>(_propertyId) != _value;
        }
    }
}