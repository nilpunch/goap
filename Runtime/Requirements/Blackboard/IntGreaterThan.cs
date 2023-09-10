using System;

namespace GOAP
{
    public class IntGreaterThan<TKey> : IntGreaterEqualThan<TKey> where TKey : IEquatable<TKey>
    {
        public IntGreaterThan(TKey key, int value, int multiplier = 1) : base(key, value + 1, multiplier)
        {
        }
    }
}