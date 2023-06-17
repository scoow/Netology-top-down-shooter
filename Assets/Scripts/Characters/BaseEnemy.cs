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
        [SerializeField] private SubscribeManager _subscribeManager;//�������� �������
        [SerializeField] private PlayerProgress _playerProgress;
        [SerializeField] private LootExample _exampleLoot;
        [SerializeField] private BloodStain _bloodStain;
        /*[SerializeField] */private Animation_Controller _animation_Controller;
        private CapsuleCollider _capsuleCollider;
        private EnemyMove _enemyMove;
        private PlayerControl _playerControl;
        private LootController _lootController;

        private Enemy_Data _enemy_Data;
        private Enemy_UI _enemy_UI;       

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
        }

        public void Respawn(/*int maxHP*/)
        {
            _enemy_Data.CurrentHP = _enemy_Data.CharacterData_SO.Health;
            _enemy_UI.SliderHP.value = _enemy_Data.CurrentHP;
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

            _enemyMove.SetNewTarget(transform.transform);//������ ���� �� ������ ����, ����� ������ �� ���������

            _animation_Controller.EnemyState = EnemyAnimationState.Death;
            _enemyMove.MaxSpeed = 0f;
            _capsuleCollider.enabled = false;
            _animation_Controller.DeathAnimation();
            InstantiateBloodStain();
        }

        private async void InstantiateBloodStain()
        {
            Instantiate(_bloodStain, new Vector3(transform.position.x, 0.05f, transform.position.z), Quaternion.AngleAxis(90, Vector3.right)); //�������� �� ��� �������� ��� �������
            await UniTask.Delay(100);
        }
    }
}