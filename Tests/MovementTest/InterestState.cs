using UnityEngine;

namespace GOAP
{
    public struct InterestState
    {
        public InterestState(Vector3 position, int collectableValue)
        {
            Position = position;
            CollectableValue = collectableValue;
        }

        public Vector3 Position { get; set; }
        
        public int CollectableValue { get; set; }
    }
}