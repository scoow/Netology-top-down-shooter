using TDShooter.Configs;
using TDShooter.Enemies;
using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.Input;
using TDShooter.UI;
using UnityEngine;
using UnityEngine.AI;

namespace TDShooter.Characters
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class BaseEnemy : Character
    {
        private SubscribeManager _subscribeManager;
        private Animation_Controller _animation_Controller;
        private CapsuleCollider _capsuleCollider;
        private EnemyMove _enemyMove;
        private PlayerControl _playerControl;

        private Enemy_Data _enemy_Data;
        private Enemy_UI _enemy_UI;
        private �haracterType _�haracterType;
        public �haracterType CharacterType => _�haracterType;
        public EnemyAnimationState EnemyAnimationState => _animation_Controller.EnemyState;
        private bool _isBoss = false;

        private void Awake()
        {
            _enemyMove = GetComponent<EnemyMove>();
            _capsuleCollider = GetComponent<CapsuleCollider>();

            _animation_Controller = GetComponentInChildren<Animation_Controller>();
            if (_animation_Controller == null )
            {
                _isBoss = true;
            }

            _enemy_Data = GetComponent<Enemy_Data>();
            _character_Data = _enemy_Data as Character_Data;
            _enemy_UI = GetComponent<Enemy_UI>();
            _character_UI = _enemy_UI as Character_UI;
        }

        public void InjectReferences(PlayerControl playerControl, SubscribeManager subscribeManager)
        {
            _playerControl = playerControl;
            _subscribeManager = subscribeManager;
        }

        public void Respawn()
        {
            _enemy_Data.CurrentHP = _enemy_Data.CharacterData_SO.Health;
            _enemy_UI.SliderHP.value = _enemy_Data.CurrentHP;
            _enemyMove?.SetNewTarget(_playerControl.transform);
            _enemyMove?.SetMaxSpeed(_enemy_Data.SpeedMove);
            _enemy_UI.HideSliderHP();

            _�haracterType = _character_Data.�haracterType;
            _animation_Controller.SetEnemyAnimationState(EnemyAnimationState.Move);
            _subscribeManager.PostNotification(enums.GameEventType.EnemySpawned, this);
        }

        private void OnEnable()
        {
            _capsuleCollider.enabled = true;
        }
        public override void Die()
        {
            _capsuleCollider.enabled = false;
            _subscribeManager?.PostNotification(enums.GameEventType.EnemyDied, this);

            _enemyMove?.SetNewTarget(transform);//������ ���� �� ������ ����, ����� ������ �� ���������

            _enemy_UI.HideSliderHP();


            NavMeshAgent navMeshAgent;
            if (_isBoss)
            {
                var animator = GetComponent<Animator>();
                animator.SetInteger("IndexDeath", 1);
                /*                animator.SetBool("Atack", false);
                                animator.SetBool("Run", false);
                                animator.SetBool("Spawn", false);*/
/*                navMeshAgent = GetComponent<NavMeshAgent>();
                navMeshAgent.speed = 0;*/

                var navMeshMove = GetComponent<Enemy_NavMeshMove>();
                navMeshMove.enabled = false;
            }
            else
            {
                _animation_Controller.SetEnemyAnimationState(EnemyAnimationState.Death);
                _animation_Controller.DeathAnimation();

                bool assist = TryGetComponent<NavMeshAgent>(out navMeshAgent);
                if (assist)
                {
                    var navMeshMove = GetComponent<Enemy_NavMeshMove>();
                    navMeshMove.enabled = false;
                }
                

            }

            _enemyMove?.SetMaxSpeed(0f);
        }
    }
}