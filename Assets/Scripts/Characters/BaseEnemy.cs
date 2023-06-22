using Cysharp.Threading.Tasks;
using TDShooter.Configs;
using TDShooter.Enemies;
using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.Input;
using TDShooter.Managers;
using UnityEngine;

namespace TDShooter.Characters
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class BaseEnemy : Character
    {
        private SubscribeManager _subscribeManager;//�������� �������
        private PlayerProgress _playerProgress;
        [SerializeField] private LootExample _exampleLoot;
        [SerializeField] private BloodStain _bloodStain;
        private Animation_Controller _animation_Controller;
        private CapsuleCollider _capsuleCollider;
        private EnemyMove _enemyMove;
        private PlayerControl _playerControl;
        private LootController _lootController;

        private Enemy_Data _enemy_Data;
        private Enemy_UI _enemy_UI;
        private �haracterType _�haracterType;
        public �haracterType CharacterType => _�haracterType;

        private void Awake()
        {
            _enemyMove = GetComponent<EnemyMove>();
            _playerControl = FindObjectOfType<PlayerControl>();
            _capsuleCollider = GetComponent<CapsuleCollider>();
            _subscribeManager = FindObjectOfType<SubscribeManager>();//�������� �������� �� ���� 

            _lootController = FindObjectOfType<LootController>();
            _animation_Controller = GetComponentInChildren<Animation_Controller>();

            _enemy_Data = GetComponent<Enemy_Data>();
            _character_Data = _enemy_Data as Character_Data;
            _enemy_UI = GetComponent<Enemy_UI>();
            _character_UI = _enemy_UI as Character_UI;
        }

        private void Start()
        {
            _playerProgress = FindObjectOfType<PlayerProgress>();

            _subscribeManager.AddListener(enums.GameEventType.EnemyDied, _playerProgress, true);
            //��������� _playerProgress � ��������� ������� "������ �����", �������� true �������� ��� ��������� ���� ���� ���  
            _subscribeManager.AddListener(enums.GameEventType.EnemyDied, _lootController, true);

            
        }

        public void Respawn()
        {
            _enemy_Data.CurrentHP = _enemy_Data.CharacterData_SO.Health;
            _enemy_UI.SliderHP.value = _enemy_Data.CurrentHP;
            _enemyMove.SetNewTarget(_playerControl.transform);
            _enemyMove.SetMaxSpeed(_enemy_Data.SpeedMove);
            _enemy_UI.HideSliderHP();

            _�haracterType = _character_Data.�haracterType;
            _subscribeManager.PostNotification(enums.GameEventType.EnemySpawned, this);
        }

        private void OnEnable()
        {
            _capsuleCollider.enabled = true;
        }
        public override void Die()
        {
            _subscribeManager.PostNotification(enums.GameEventType.EnemyDied, this);

            _enemyMove.SetNewTarget(transform);//������ ���� �� ������ ����, ����� ������ �� ���������

            _enemy_UI.HideSliderHP();

            _animation_Controller.SetEnemyAnimationState(EnemyAnimationState.Death);
            _animation_Controller.DeathAnimation();

            _enemyMove.SetMaxSpeed(0f);
            _capsuleCollider.enabled = false;
            
            InstantiateBloodStain();
        }

        private async void InstantiateBloodStain()
        {
            Instantiate(_bloodStain, new Vector3(transform.position.x, 0.05f, transform.position.z), Quaternion.AngleAxis(90, Vector3.right)); //�������� �� ��� �������� ��� �������
            await UniTask.Delay(100);
        }
    }
}