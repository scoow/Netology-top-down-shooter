using UnityEngine;

namespace TDShooter
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseUnit : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        public BaseUnit Target { get; set; }        
        public float Mass => _rigidbody.mass;
        public float WanderAngle { get; set; }

        protected virtual void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();            
        }

        public Vector3 GetVelocity(IgnoreAxisType ignore = IgnoreAxisType.None)
        {
            return UpdateIgnoreAxis(_rigidbody.velocity, ignore);
        }

        public void SetVelocity(Vector3 velocity, IgnoreAxisType ignore = IgnoreAxisType.None)
        {
            _rigidbody.velocity = UpdateIgnoreAxis(velocity, ignore);
        }

        private Vector3 UpdateIgnoreAxis(Vector3 velocity, IgnoreAxisType ignore)
        {
            if ((ignore & IgnoreAxisType.None) == IgnoreAxisType.None) return velocity;
            else if ((ignore & IgnoreAxisType.X) == IgnoreAxisType.X) velocity.x = 0f;
            else if ((ignore & IgnoreAxisType.Y) == IgnoreAxisType.Y) velocity.y = 0f;
            else if ((ignore & IgnoreAxisType.Z) == IgnoreAxisType.Z) velocity.z = 0f;

            return velocity;
        }

    }
    public enum IgnoreAxisType : byte
    {
        None = 0,
        X = 1,
        Y = 2,
        Z = 4
    }
}