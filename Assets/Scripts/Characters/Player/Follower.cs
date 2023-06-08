using UnityEngine;

namespace TDShooter.Weapons
{
    public abstract class Follower : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private float _smoothing;
        private Vector3 _offset;

        void Start()
        {
            _offset = transform.position - _targetTransform.position;
        }

        protected void Move(float deltaTime)
        {
            var nextPosition = Vector3.Lerp(transform.position, _targetTransform.position + _offset, deltaTime * _smoothing);
            transform.position = nextPosition;
        }
    }
}