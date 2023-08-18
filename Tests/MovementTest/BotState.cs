using UnityEngine;

namespace GOAP
{
    public struct BotState
    {
        public BotState(Vector3 position, float distancePerMove, int collectedValue)
        {
            Position = position;
            DistancePerMove = distancePerMove;
            CollectedValue = collectedValue;
        }

        public Vector3 Position { get; set; }
        
        public float DistancePerMove { get; set; }
        
        public int CollectedValue { get; set; }
    }
}