using System;

namespace GOAP
{
    public class IntLessThan<TKey> : IntLessEqualThan<TKey> where TKey : IEquatable<TKey>
    {
        public IntLessThan(TKey key, int value, int multiplier = 1) : base(key, value - 1, multiplier)
        {
        }
    }
}