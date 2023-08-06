using Common;
using GOAP.Effects;

namespace GOAP
{
    public class SetLocationEffect : IEffect
    {
        private readonly PropertyId _propertyId;
        private readonly Location _value;

        public SetLocationEffect(PropertyId propertyId, Location value)
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
            return state.Get<Location>(_propertyId) != _value;
        }
    }
}