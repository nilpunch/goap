using Common;

namespace GOAP
{
    public class BoolSetEffect : IEffect<IReadOnlyBlackboard>
    {
        private readonly PropertyId _propertyId;
        private readonly bool _value;

        public BoolSetEffect(PropertyId propertyId, bool value)
        {
            _propertyId = propertyId;
            _value = value;
        }

        public IReadOnlyBlackboard Modify(IReadOnlyBlackboard state)
        {
            var newState = state.Clone();
            newState.Set(_propertyId, _value);
            return newState;
        }

        public bool IsChangeSomething(IReadOnlyBlackboard state)
        {
            return state.Get<bool>(_propertyId) != _value;
        }
    }
}