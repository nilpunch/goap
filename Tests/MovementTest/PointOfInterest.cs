using UnityEngine;

namespace GOAP.Test.Movement
{
    public class PointOfInterest : MonoBehaviour
    {
        [SerializeField] private int _collectableValue;
        
        public PropertyId Id => new PropertyId(gameObject.GetInstanceID());
        public InterestState State => new InterestState(transform.position, _collectableValue, gameObject.name);
    }
}