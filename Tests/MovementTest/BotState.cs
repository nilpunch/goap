using System;
using UnityEngine;

namespace GOAP.Test.Movement
{
    public struct BotState : IEquatable<BotState>
    {
        private readonly string _name;

        public BotState(Vector3 position, float maxDistancePerMove, int collectedValue, string name)
        {
            _name = name;
            Position = position;
            MaxDistancePerMove = maxDistancePerMove;
            CollectedValue = collectedValue;
        }

        public Vector3 Position { get; set; }
        
        public float MaxDistancePerMove { get; set; }
        
        public int CollectedValue { get; set; }

        public bool Equals(BotState other)
        {
            return Position.Equals(other.Position) && MaxDistancePerMove.Equals(other.MaxDistancePerMove) && CollectedValue == other.CollectedValue;
        }

        public override bool Equals(object obj)
        {
            return obj is BotState other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Position, MaxDistancePerMove, CollectedValue);
        }

        public override string ToString()
        {
            return _name;
        }
    }
}