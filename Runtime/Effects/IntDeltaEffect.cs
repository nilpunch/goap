using Common;

namespace GOAP
{
    public class IntDeltaEffect : IEffect<IReadOnlyBlackboard>
    {
        private readonly PropertyId _propertyId;
        private readonly int _delta;

        public IntDeltaEffect(PropertyId propertyId, int delta)
        {
            _propertyId = propertyId;
            _delta = delta;
        }

        public IReadOnlyBlackboard Modify(IReadOnlyBlackboard state)
        {
            var value = state.Get<int>(_propertyId);

            var newState = state.Clone();
            newState.Set(_propertyId, value + _delta);
            return newState;
        }

        public bool IsChangeSomething(IReadOnlyBlackboard state)
        {
            return _delta != 0;
        }
    }
}