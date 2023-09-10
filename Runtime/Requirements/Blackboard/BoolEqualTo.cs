using System;

namespace GOAP
{
    public class BoolEqualTo<TKey> : IRequirement<IBoard<TKey, bool>> where TKey : IEquatable<TKey>
    {
        private readonly TKey _key;
        private readonly bool _value;
        private readonly int _difficulty;

        public BoolEqualTo(TKey key, bool value, int difficulty = 1)
        {
            _key = key;
            _value = value;
            _difficulty = difficulty;
        }

        public int MismatchCost(IBoard<TKey, bool> state)
        {
            return state[_key] == _value ? 0 : _difficulty;
        }

        public override string ToString()
        {
            return _key + " == " + _value;
        }
    }
}