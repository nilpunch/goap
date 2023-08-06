using System;

namespace GOAP.GoapPathfind.AStar
{
    public struct Distance : IComparable<Distance>, IEquatable<Distance>
    {
        public static Distance Zero => new Distance(0);

        public Distance(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public static Distance operator +(Distance a, Distance b)
            => new Distance(a.Value + b.Value);

        public static Distance operator -(Distance a, Distance b)
            => new Distance(a.Value - b.Value);

        public static bool operator >(Distance a, Distance b)
            => a.Value > b.Value;

        public static bool operator <(Distance a, Distance b)
            => a.Value < b.Value;

        public static bool operator >=(Distance a, Distance b)
            => a.Value >= b.Value;

        public static bool operator <=(Distance a, Distance b)
            => a.Value <= b.Value;

        public static bool operator ==(Distance a, Distance b)
            => a.Value.Equals(b.Value);

        public static bool operator !=(Distance a, Distance b)
            => !a.Value.Equals(b.Value);

        public override string ToString() => $"{Value:F2}s";

        public override bool Equals(object obj) => obj is Distance duration && Equals(duration);

        public bool Equals(Distance other) => Value == other.Value;

        public int CompareTo(Distance other) => Value.CompareTo(other.Value);

        public override int GetHashCode() => -1609761766 + Value.GetHashCode();
    }
}