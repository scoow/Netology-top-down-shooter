using System;
using System.Collections.Generic;
using System.Linq;
using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.Input;
using TDShooter.Level;
using TDShooter.Talents;
using UnityEngine;
using Zenject;

namespace TDShooter.Characters
{
    public class SpawnAssistant : MonoBehaviour, IEventListener
    {
        /// <summary>
        /// ��� ������
        /// </summary>
        private readonly Dictionary<�haracterType, EnemiesPool> _enemiesPool = new();
        [Inject]
        private readonly PlayerControl _playerControl;
        [Inject]
        private readonly SubscribeManager _subscribeManager;
        [Inject]
        private readonly TilesManager _tilesManager;
        [Inject]
        private readonly Transform _enemiesContainer;
        [Inject]
        private readonly NuclearChargeEffect _nuclearChargeEffect;
        private List<EnemiesSpawner> _unitSpawners = new();
        public List<EnemiesSpawner> UnitSpawners => _unitSpawners;//���������� �� enumerable

        [SerializeField]
        private float _enemySpawnCooldown = 2;
        [SerializeField, Range(1, 2)]
        private float _SpawnLoodownReductionCoefficient;//������ ������� ��������� ����� ����� ���������� ������
        [SerializeField]
        private bool _spanwEnabled;

        private float _timer;

        private void Start()
        {
            _unitSpawners = FindObjectsOfType<EnemiesSpawner>().ToList();//zenject
            _timer = _enemySpawnCooldown;
            _spanwEnabled = true;
            InitEnemyPool();
        }
        /// <summary>
        /// ������������� ���� ������
        /// </summary>
        private void InitEnemyPool()
        {
            _enemiesPool.Add(�haracterType.FastMeleeEnemy, new(Resources.Load<BaseEnemy>("Prefabs/Enemy/FirstEnemy/Enemy"), �haracterType.FastMeleeEnemy, _enemiesContainer, _playerControl, _subscribeManager, 2));
            _enemiesPool.Add(�haracterType.Spider, new(Resources.Load<BaseEnemy>("Prefabs/Enemy/Spiders/Prefabs/Black Widow 1"), �haracterType.Spider, _enemiesContainer, _playerControl, _subscribeManager, 2));
            _enemiesPool.Add(�haracterType.BossAssistant, new(Resources.Load<BaseEnemy>("Prefabs/Enemy/FirstEnemy/Enemy_Assist"), �haracterType.BossAssistant, _enemiesContainer, _playerControl, _subscribeManager, 2));
            _enemiesPool.Add(�haracterType.Boss, new(Resources.Load<BaseEnemy>("Prefabs/Enemy/BigBoss/EnemyBoss"), �haracterType.Boss, _enemiesContainer, _playerControl, _subscribeManager, 1));
            
        }
        /// <summary>
        /// ����� �� �������
        /// </summary>
        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _timer = _enemySpawnCooldown;
                if (_spanwEnabled)
                {
                    SpawnEnemyAtRandomTile();
                }
            }
        }

        private void SpawnEnemyAtRandomTile()
        {
            BaseEnemy enemy = _enemiesPool[(�haracterType)UnityEngine.Random.Range(1, Enum.GetNames(typeof(�haracterType)).Length - 2)].GetAviableOrCreateNew();

            int randompoint = UnityEngine.Random.Range(0, _unitSpawners.Count());
            Tile_Marker parentTile = _unitSpawners[randompoint].GetComponentInParent<Tile_Marker>();
            //��������, �� ����������� �� ��� ����. � ��� �� �������

            while (_tilesManager.IsInMiddle(parentTile))
            {
                randompoint = UnityEngine.Random.Range(0, _unitSpawners.Count());
                parentTile = _unitSpawners[randompoint].GetComponentInParent<Tile_Marker>();
            }

            enemy.transform.position = _unitSpawners[randompoint].transform.position;
            enemy.Respawn();
        }
        public void SpawnEnemy(Vector3 position, �haracterType �haracterType)
        {
            BaseEnemy enemy = _enemiesPool[�haracterType].GetAviableOrCreateNew();
            enemy.Respawn();

            var navMeshMove = enemy.GetComponent<Enemy_NavMeshMove>();
            navMeshMove.enabled = true;

            enemy.transform.position = position;
        }
        public List<BaseEnemy> FindAllEnemies()
        {
            List<BaseEnemy> enemies = _enemiesPool[�haracterType.FastMeleeEnemy].GetActiveUnits();
            enemies.AddRange(_enemiesPool[�haracterType.Spider].GetActiveUnits());
            return enemies;
        }
        private void TurningSpawnOnOrOff(bool toggle)
        {
            _spanwEnabled = toggle;
        }

        public void OnEvent(GameEventType eventType, Component sender, UnityEngine.Object param = null)
        {
            switch (eventType)
            {
                case GameEventType.PlayerLevelUp:
                    _enemySpawnCooldown /= _SpawnLoodownReductionCoefficient;
                    if (_enemySpawnCooldown < 1f)
                        _enemySpawnCooldown = 1f;
                    //���������� ����� ������ ��������� � 1 ���
                    break;
                case GameEventType.PortalActivated:
                    TurningSpawnOnOrOff(false);
                    _nuclearChargeEffect.Activate();
                    break;
                default:
                    break;
            }
        }
    }
}