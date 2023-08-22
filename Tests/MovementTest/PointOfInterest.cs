using Common;
using UnityEngine;

namespace GOAP
{
    public class PointOfInterest : MonoBehaviour
    {
        [SerializeField] private int _collectableValue;
        
        public PropertyId Id => new PropertyId(gameObject.GetInstanceID(), gameObject.name);
        public InterestState State => new InterestState(transform.position, _collectableValue);
    }
}