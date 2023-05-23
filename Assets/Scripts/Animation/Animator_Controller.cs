using UnityEngine;

namespace TDShooter.Characters
{
    public class Animator_Controller : MonoBehaviour
    {
        private Animator _animator;
        private int _runAnimation;

        public void StepSound()
        {
            Debug.Log("Step");//todo заменить на звук
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _runAnimation = Animator.StringToHash("Run");
        }

        public void Move(Vector2 incomingValue, Quaternion rotation)
        {
            //Debug.Log("move" + move);
            //Debug.Log("rotation" + rotation);
            Vector2 move;
            move = incomingValue * (0.5f - rotation.y);

            move.Normalize();
            //Debug.Log("result" + move);

            _animator.SetFloat("Forward", move.y);
            _animator.SetFloat("Turn", move.x);
        }
    }
}