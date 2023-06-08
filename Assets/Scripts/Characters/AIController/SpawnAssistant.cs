using System;
using System.Collections.Generic;
using System.Linq;
using TDShooter.enums;
using TDShooter.Input;
using TDShooter.Level;
using UnityEngine;
using Zenject;
using static UnityEngine.EventSystems.EventTrigger;

namespace TDShooter.Characters
{
    public class SpawnAssistant : MonoBehaviour
    {
        /// <summary>
        /// Пул юнитов
        /// </summary>
        private readonly Dictionary<СharacterType, EnemiesPool> _enemiesPool = new();
        public Dictionary<СharacterType, EnemiesPool> EnemiesPool => _enemiesPool;
        [Inject]
        private readonly PlayerControl _playerControl;

        [Inject]
        private readonly TilesManager _tilesManager;
        [Inject]
        private readonly Transform _enemiesContainer;
        private List<EnemiesSpawner> _unitSpawners = new();
        //todo Добавить таймер спавна для каждого типа врагов
        [SerializeField]
        private float _enemySpawnCooldown = 2;
        private float _timer;

        private void Start()
        {
            _unitSpawners = FindObjectsOfType<EnemiesSpawner>().ToList();//zenject
            _timer = _enemySpawnCooldown;
            InitEnemyPool();
        }
        /// <summary>
        /// Инициализация пула врагов
        /// </summary>
        private void InitEnemyPool()
        {
            _enemiesPool.Add(СharacterType.FastMeleeEnemy, new(Resources.Load<BaseEnemy>("Prefabs/Enemy/FirstEnemy/Enemy"), СharacterType.FastMeleeEnemy, _enemiesContainer, _playerControl));
            _enemiesPool.Add(СharacterType.Spider, new(Resources.Load<BaseEnemy>("Prefabs/Enemy/Spiders/Prefabs/Black Widow 1"), СharacterType.Spider, _enemiesContainer, _playerControl));
            //пул для босса
            //_enemiesPool.Add(СharacterType.Devil_Bulldog, new(Resources.Load<BossEnemy>("Prefabs/Enemy/BigBoss/DeepNest/Devil_Bulldog_Lite/EnemyBoss"), СharacterType.Devil_Bulldog, _enemiesContainer, _playerControl, 1));
        }
        /// <summary>
        /// Для теста - спавн на клавишу B
        /// </summary>
        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _timer = _enemySpawnCooldown;
                SpawnEnemyAtRandomTile();
            }
/*            if (UnityEngine.Input.GetKeyDown(KeyCode.B))
            {
                
            }*/
        }

        private void SpawnEnemyAtRandomTile()
        {

            BaseEnemy enemy = _enemiesPool[(СharacterType)UnityEngine.Random.Range(1,
                                                                                         Enum.GetNames(typeof(СharacterType)).Length)].GetAviableOrCreateNew();

            int randompoint = UnityEngine.Random.Range(0, _unitSpawners.Count());
            Tile_Marker parentTile = _unitSpawners[randompoint].GetComponentInParent<Tile_Marker>();
            //проверка, не центральный ли это тайл. в нём не спавним

            while (_tilesManager.IsInMiddle(parentTile))
            {
                randompoint = UnityEngine.Random.Range(0, _unitSpawners.Count());
                parentTile = _unitSpawners[randompoint].GetComponentInParent<Tile_Marker>();
            }

            enemy.transform.position = _unitSpawners[randompoint].transform.position;
            enemy.GetComponent<BaseEnemy>().Respawn();
        }
    }
}
