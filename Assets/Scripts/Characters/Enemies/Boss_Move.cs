using TDShooter.Input;
using UnityEngine;
using UnityEngine.AI;

namespace TDShooter.Enemies
{
    public class Boss_Move : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private PlayerControl _playerControl;

        //private float timeOut = 1f;
        private int _attackAnimation;
        private int _moveAnimation;
        private int _deathAnimation;

        public float distance;
        //private bool isMoving;
        /*    public bool finishAtack = true;
            public bool atack = false;*/

        private float _checkDistanceCoolDown = 0.5f;
        public float _checkDistanceTimer;

        private float _attackCoolDown = 3.2f;
        public float _attackTimer;

        private void Start()
        {
            _attackAnimation = Animator.StringToHash("Atack");
            _moveAnimation = Animator.StringToHash("Move");
            _deathAnimation = Animator.StringToHash("Death");

            _checkDistanceTimer = _checkDistanceCoolDown;
        }

        public void Update()
        {
            _checkDistanceTimer -= Time.deltaTime;
            _attackTimer -= Time.deltaTime;

            if (_checkDistanceTimer < 0)
            {
                _checkDistanceTimer = _checkDistanceCoolDown;
                if (_attackTimer < 0)
                    CheckDistance();
            }
        }

        private void CheckDistance()
        {
            distance = Vector3.Distance(transform.position, _playerControl.transform.position);
            if (distance <= _agent.stoppingDistance)
            {
                _animator.SetTrigger(_attackAnimation);
                _attackTimer = _attackCoolDown;
                /*var task = await Waiting();*/
            }
            else
            {
                _agent.SetDestination(_playerControl.transform.position);
                _animator.SetTrigger(_moveAnimation);
            }
        }
        /*private async UniTask Waiting()
        {
            finishAtack = false;
            await UniTask.Delay(3200);
            finishAtack = true;
        }*/
    }
}