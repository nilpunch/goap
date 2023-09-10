using System;
using UnityEngine;

namespace GOAP.Test.Movement
{
    public struct InterestState : IEquatable<InterestState>
    {
        private readonly string _name;

        public InterestState(Vector3 position, int collectableValue, string name)
        {
            _name = name;
            Position = position;
            CollectableValue = collectableValue;
        }

        public Vector3 Position { get; set; }
        
        public int CollectableValue { get; set; }

        public bool Equals(InterestState other)
        {
            return Position.Equals(other.Position) && CollectableValue == other.CollectableValue;
        }

        public override bool Equals(object obj)
        {
            return obj is InterestState other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Position, CollectableValue);
        }

        public override string ToString()
        {
            return _name;
        }
    }
}