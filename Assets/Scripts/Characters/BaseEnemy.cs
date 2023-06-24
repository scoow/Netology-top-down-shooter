using TDShooter.Configs;
using TDShooter.Enemies;
using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.Input;
using UnityEngine;

namespace TDShooter.Characters
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class BaseEnemy : Character
    {
        private SubscribeManager _subscribeManager;//ìåíåäæåğ ñîáûòèé zen 2
        private Animation_Controller _animation_Controller;
        private CapsuleCollider _capsuleCollider;
        private EnemyMove _enemyMove;
        private PlayerControl _playerControl;//zen 1

        private Enemy_Data _enemy_Data;
        private Enemy_UI _enemy_UI;
        private ÑharacterType _ñharacterType;
        public ÑharacterType CharacterType => _ñharacterType;
        public EnemyAnimationState EnemyAnimationState => _animation_Controller.EnemyState;

        private void Awake()
        {
            _enemyMove = GetComponent<EnemyMove>();
            //_playerControl = FindObjectOfType<PlayerControl>();
            _capsuleCollider = GetComponent<CapsuleCollider>();
            //_subscribeManager = FindObjectOfType<SubscribeManager>();//äîáàâèòü èíúåêöèş îò ïóëà 

            _animation_Controller = GetComponentInChildren<Animation_Controller>();

            _enemy_Data = GetComponent<Enemy_Data>();
            _character_Data = _enemy_Data as Character_Data;//óáğàòü?
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
            _enemyMove.SetNewTarget(_playerControl.transform);
            _enemyMove.SetMaxSpeed(_enemy_Data.SpeedMove);
            _enemy_UI.HideSliderHP();

            _ñharacterType = _character_Data.ÑharacterType;
            _animation_Controller.SetEnemyAnimationState(EnemyAnimationState.Move);
            _subscribeManager.PostNotification(enums.GameEventType.EnemySpawned, this);
        }

        private void OnEnable()
        {
            _capsuleCollider.enabled = true;
        }
        public override void Die()
        {
            _subscribeManager.PostNotification(enums.GameEventType.EnemyDied, this);

            _enemyMove.SetNewTarget(transform);//ìåíÿåì öåëü íà ñàìîãî ñåáÿ, ÷òîáû ìîäåëü íå êğóòèëàñü

            _enemy_UI.HideSliderHP();

            _animation_Controller.SetEnemyAnimationState(EnemyAnimationState.Death);
            _animation_Controller.DeathAnimation();

            _enemyMove.SetMaxSpeed(0f);
            _capsuleCollider.enabled = false;
        }
    }
}