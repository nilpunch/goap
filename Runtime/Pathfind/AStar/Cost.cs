using System;

namespace GOAP.AStar
{
    public struct Cost : IComparable<Cost>, IEquatable<Cost>
    {
        public static Cost Zero => new Cost(0);

        public Cost(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public static Cost operator +(Cost a, Cost b)
            => new Cost(a.Value + b.Value);

        public static Cost operator -(Cost a, Cost b)
            => new Cost(a.Value - b.Value);

        public static bool operator >(Cost a, Cost b)
            => a.Value > b.Value;

        public static bool operator <(Cost a, Cost b)
            => a.Value < b.Value;

        public static bool operator >=(Cost a, Cost b)
            => a.Value >= b.Value;

        public static bool operator <=(Cost a, Cost b)
            => a.Value <= b.Value;

        public static bool operator ==(Cost a, Cost b)
            => a.Value.Equals(b.Value);

        public static bool operator !=(Cost a, Cost b)
            => !a.Value.Equals(b.Value);

        public override string ToString() => $"{Value:F2}s";

        public override bool Equals(object obj) => obj is Cost duration && Equals(duration);

        public bool Equals(Cost other) => Value == other.Value;

        public int CompareTo(Cost other) => Value.CompareTo(other.Value);

        public override int GetHashCode() => -1609761766 + Value.GetHashCode();
    }
}