using Common;

namespace GOAP.Effects
{
    public class IntDeltaEffect : IEffect
    {
        private readonly PropertyId _propertyId;
        private readonly int _delta;

        public IntDeltaEffect(PropertyId propertyId, int delta)
        {
            _propertyId = propertyId;
            _delta = delta;
        }

        public void Modify(IState state)
        {
            var value = state.Get<int>(_propertyId);
            state.Set(_propertyId, value + _delta);
        }

        public bool IsChangeSomething(IReadOnlyState state)
        {
            return _delta != 0;
        }
    }
}