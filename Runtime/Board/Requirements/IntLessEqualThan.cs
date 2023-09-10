using System;

namespace GOAP
{
    public class IntLessEqualThan<TKey> : IRequirement<IBoard<TKey, int>> where TKey : IEquatable<TKey>
    {
        private readonly TKey _key;
        private readonly int _value;
        private readonly int _multiplier;

        public IntLessEqualThan(TKey key, int value, int multiplier = 1)
        {
            _key = key;
            _value = value;
            _multiplier = multiplier;
        }

        public int MismatchCost(IBoard<TKey, int> state)
        {
            return Math.Max(0, state[_key] - _value) * _multiplier;
        }
    }
}