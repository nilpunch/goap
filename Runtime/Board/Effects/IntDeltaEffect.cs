using System;

namespace GOAP
{
    public class IntDeltaEffect<TKey> : IEffect<IBoard<TKey, int>> where TKey : IEquatable<TKey>
    {
        private readonly TKey _key;
        private readonly int _delta;

        public IntDeltaEffect(TKey key, int delta)
        {
            _key = key;
            _delta = delta;
        }

        public IBoard<TKey, int> Modify(IBoard<TKey, int> state)
        {
            var newState = state.CloneAsWriteable();
            newState[_key] = state[_key] + _delta;
            return newState;
        }

        public bool IsChangeSomething(IBoard<TKey, int> state)
        {
            return _delta != 0;
        }
    }
}