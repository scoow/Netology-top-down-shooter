using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace TDShooter
{
    public class Animation_IK : MonoBehaviour
    {
        [SerializeField] Rig _rightForward;
        [SerializeField] Rig _leftForward;
        [SerializeField] Rig _rightBack;
        [SerializeField] Rig _leftBack;

        [SerializeField] private float _speed;
        private bool _isMoveRightForward;

        private void Start()
        {
            _isMoveRightForward = true;
        }


        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (_isMoveRightForward)
            {
                _rightForward.weight -= 0.1f * Time.deltaTime * _speed;
                _leftBack.weight -= 0.1f * Time.deltaTime * _speed;

                _leftForward.weight += 0.1f * Time.deltaTime * _speed;
                _rightBack.weight += 0.1f * Time.deltaTime * _speed;

                if (_rightForward.weight <= 0) _isMoveRightForward = false;
            }

            if (!_isMoveRightForward)
            {
                _rightForward.weight += 0.1f * Time.deltaTime * _speed;
                _leftBack.weight += 0.1f * Time.deltaTime * _speed;

                _leftForward.weight -= 0.1f * Time.deltaTime * _speed;
                _rightBack.weight -= 0.1f * Time.deltaTime * _speed;

                if (_rightForward.weight >= 1) _isMoveRightForward = true;
            }
        }
    }
}