using UnityEngine;

namespace GOAP.Test.Movement
{
    public class Bot : MonoBehaviour
    {
        [SerializeField] private float _maxDistancePerMove;
        [SerializeField] private int _collectedValue;
        
        public PropertyId Id => new PropertyId(gameObject.GetInstanceID());
        public BotState State => new BotState(transform.position, _maxDistancePerMove, _collectedValue, gameObject.name);
    }
}