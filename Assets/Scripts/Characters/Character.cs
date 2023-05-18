using UnityEngine;
using TDShooter.Enemies;
using TDShooter.EventManager;
using TDShooter.Input;

namespace TDShooter.Characters
{
    /// <summary>
    /// ��������. �� ������� - �����-�������� ��� ������ � ������
    /// </summary>
    public class Character : MonoBehaviour, IHaveHP
    {
        [SerializeField]
        private int _hp;
        [SerializeField] private LootExample _exampleLoot;
        [SerializeField] private PlayerProgress _playerProgress;
        [SerializeField] private Animation_Controller _animation_Controller;
        private CapsuleCollider _capsuleCollider;
        private EnemyMove _enemyMove;
        public int HP => _hp;

        [SerializeField] private SubscribeManager _subscribeManager;//�������� �������
        private PlayerControl _playerControl;

        private void Awake()
        {
            _playerControl = FindObjectOfType<PlayerControl>();
            _subscribeManager = FindObjectOfType<SubscribeManager>();//����������� ������ �� ������� ������
            _enemyMove = GetComponent<EnemyMove>();
            _capsuleCollider = GetComponent<CapsuleCollider>();
        }
        private void Start()
        {
            _playerProgress = FindObjectOfType<PlayerProgress>();
            
            _subscribeManager.AddListener(enums.GameEventType.EnemyDied, _playerProgress, true);
            //��������� _playerProgress � ��������� ������� "������ �����", �������� true �������� ��� ��������� ���� ���� ���  
        }

        public void Respawn(int maxHP)
        {
            _hp = maxHP;
            _enemyMove.SetNewTarget(_playerControl.transform);
        }
        public void Die()
        {            
            if(_playerProgress.CheckChance() < _playerProgress.ChanceDroopLoot)
            {
                LootExample loot = Instantiate(_exampleLoot);
                loot.transform.position = transform.position;
            }
            _subscribeManager.PostNotification(enums.GameEventType.EnemyDied, this);

            _enemyMove.SetNewTarget(transform);//������ ���� �� ������ ����, ����� ������ �� ���������

            _animation_Controller.EnemyState = EnemyAnimationState.Death;
            _enemyMove.MaxSpeed = 0f;
            _capsuleCollider.enabled = false;
            _animation_Controller.DeathAnimation();
        }

        public void TakeDamage(int damage)
        {
            _hp -= damage;
            //Debug.Log("HP ��������:" + _hp);
            if (_hp <= 0)
                Die();
        }

        public void TakeHeal(int heal)
        {
            _hp += heal;
        }
    }
}