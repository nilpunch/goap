using Common;
using UnityEngine;

namespace GOAP
{
    public class Bot : MonoBehaviour
    {
        [SerializeField] private float _maxDistancePerMove;
        [SerializeField] private int _collectedValue;
        
        public PropertyId Id => new PropertyId(gameObject.GetInstanceID(), gameObject.name);
        public BotState State => new BotState(transform.position, _maxDistancePerMove, _collectedValue);
    }
}