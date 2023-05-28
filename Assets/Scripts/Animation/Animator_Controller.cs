using TDShooter.enums;
using UnityEngine;

namespace TDShooter.Characters
{
    public class Animator_Controller : MonoBehaviour
    {
        private Animator _animator;
        private int _runAnimation;

        public void StepSound()
        {
            Debug.Log("Step");//todo �������� �� ����
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _runAnimation = Animator.StringToHash("Run");
        }

        public void Move(Vector2 incomingValue, Quaternion rotation)
        {
            //Debug.Log("move" + move);
            float eulerAnglesRotation = rotation.eulerAngles.y;
            //Debug.Log("rotation" + eulerAnglesRotation);
            Direction direction;

            if (eulerAnglesRotation < 45 || eulerAnglesRotation > 315)
            {
                direction = Direction.Up;
            }
            else
            if (eulerAnglesRotation < 135)
            {
                direction = Direction.Right;
            }
            else
            if (eulerAnglesRotation < 225)
            {
                direction = Direction.Down;
            }
            else

            {
                direction = Direction.Left;
            }

            Vector2 move;

            switch (direction)
            {
                case Direction.Up:
                    move = incomingValue;
                    break;
                case Direction.Right:
                    move.x = -incomingValue.y;
                    move.y = incomingValue.x;
                    break;
                case Direction.Down:
                    move = -incomingValue;
                    break;
                case Direction.Left:
                    move.x = incomingValue.y;
                    move.y = -incomingValue.x;
                    break;
                default:
                    move = Vector2.zero;
                    break;
            }

            move.Normalize();
            //Debug.Log("result" + move);

            _animator.SetFloat("Forward", move.y);
            _animator.SetFloat("Turn", move.x);
        }
    }
}