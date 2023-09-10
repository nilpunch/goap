using System;

namespace GOAP
{
    public class BoolSetEffect<TKey> : IEffect<IBoard<TKey, bool>> where TKey : IEquatable<TKey>
    {
        private readonly TKey _key;
        private readonly bool _value;

        public BoolSetEffect(TKey key, bool value)
        {
            _key = key;
            _value = value;
        }

        public IBoard<TKey, bool> Modify(IBoard<TKey, bool> state)
        {
            var newState = state.CloneAsWriteable();
            newState[_key] = _value;
            return newState;
        }

        public bool IsChangeSomething(IBoard<TKey, bool> state)
        {
            return state[_key] != _value;
        }
    }
}