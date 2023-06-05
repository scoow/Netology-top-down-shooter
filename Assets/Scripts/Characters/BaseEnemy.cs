using TDShooter.Enemies;
using TDShooter.EventManager;
using TDShooter.Input;
using TDShooter.Managers;
using UnityEngine;

namespace TDShooter.Characters
{
    public class BaseEnemy : Character
    {
        [SerializeField] private SubscribeManager _subscribeManager;//�������� �������
        [SerializeField] private PlayerProgress _playerProgress;
        [SerializeField] private LootExample _exampleLoot;
        [SerializeField] private Animation_Controller _animation_Controller;
        private CapsuleCollider _capsuleCollider;
        private EnemyMove _enemyMove;
        private PlayerControl _playerControl;
        private LootController _lootController;

        private void Awake()
        {
            _enemyMove = GetComponent<EnemyMove>();
            _playerControl = FindObjectOfType<PlayerControl>();
            _capsuleCollider = GetComponent<CapsuleCollider>();
            _subscribeManager = FindObjectOfType<SubscribeManager>();//�������� �������� �� ���� 

            _lootController = FindObjectOfType<LootController>();
        }

        private void Start()
        {
            _playerProgress = FindObjectOfType<PlayerProgress>();

            _subscribeManager.AddListener(enums.GameEventType.EnemyDied, _playerProgress, true);
            //��������� _playerProgress � ��������� ������� "������ �����", �������� true �������� ��� ��������� ���� ���� ���  
        }

        public void Respawn(/*int maxHP*/)
        {
            _character_Data.CurrentHP = _character_Data.CharacterData_SO.Health;
            _character_UI.SliderHP.value = _character_Data.CurrentHP;
            _enemyMove.SetNewTarget(_playerControl.transform);
            _enemyMove.MaxSpeed = 5f;//����
        }

        private void OnEnable()
        {
            _capsuleCollider.enabled = true;
        }
        public override void Die()
        {
            if (_playerProgress.CheckChance() < _playerProgress.ChanceDroopLoot)
            {
                _lootController.SpawnRandomLoot(transform.position);
            }
            _subscribeManager.PostNotification(enums.GameEventType.EnemyDied, this);

            _enemyMove.SetNewTarget(transform);//������ ���� �� ������ ����, ����� ������ �� ���������

            _animation_Controller.EnemyState = EnemyAnimationState.Death;
            _enemyMove.MaxSpeed = 0f;
            _capsuleCollider.enabled = false;
            _animation_Controller.DeathAnimation();
        }

    }
}