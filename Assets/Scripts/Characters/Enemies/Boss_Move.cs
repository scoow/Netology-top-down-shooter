using Cysharp.Threading.Tasks;
using TDShooter.enums;
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
        private int _spawnAssistAnimation;
        private int _deathAnimation;

        public float distance;
        //private bool isMoving;
        /*    public bool finishAtack = true;
            public bool atack = false;*/

        private float _checkDistanceCoolDown = 0.5f;        
        public float _checkDistanceTimer;

        private float _attackCoolDown = 3.2f;
        public float _attackTimer;

        private float _spawnAssistCoolDown = 30f;
        public float _spawnAssistTimer;
        private float _spawnAssistDuration = 10f;
        public float _spawnDurationTimer;
        private bool _isSpawn = false;


        private void Start()
        {
            _attackAnimation = Animator.StringToHash("Atack");
            _moveAnimation = Animator.StringToHash("Move");
            _spawnAssistAnimation = Animator.StringToHash("Spawn");
            _deathAnimation = Animator.StringToHash("Death");
            _checkDistanceTimer = _checkDistanceCoolDown;
            _spawnAssistTimer = _spawnAssistCoolDown;
            _spawnDurationTimer = _spawnAssistDuration;
        }

        public void Update()
        {
            _checkDistanceTimer -= Time.deltaTime;
            _attackTimer -= Time.deltaTime;
            _spawnAssistTimer -= Time.deltaTime;
            

            if(_spawnAssistTimer <0)
            {                
                _agent.speed = 0f;                
                _animator.SetBool(_attackAnimation, false);
                _animator.SetBool(_moveAnimation, false);
                _animator.SetBool(_spawnAssistAnimation, true);

                _spawnDurationTimer -= Time.deltaTime;
                if(_spawnDurationTimer < 0)
                {
                    _spawnAssistTimer = _spawnAssistCoolDown;
                    _spawnDurationTimer = _spawnAssistDuration;                    
                }
            }            

            if (_checkDistanceTimer < 0 && !_isSpawn)
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
                _agent.speed = 0f;               
                _attackTimer = _attackCoolDown;
                _animator.SetBool(_attackAnimation, true);
                _animator.SetBool(_moveAnimation, false);
                _animator.SetBool(_spawnAssistAnimation, false);
            }
            else
            {
                _agent.speed = 2.5f;                
                _agent.SetDestination(_playerControl.transform.position);
                _animator.SetBool(_attackAnimation, false);
                _animator.SetBool(_moveAnimation, true);
                _animator.SetBool(_spawnAssistAnimation, false);
            }
        }
    }
}