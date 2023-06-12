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
        /// Ïóë şíèòîâ
        /// </summary>
        private readonly Dictionary<ÑharacterType, EnemiesPool> _enemiesPool = new();
        public Dictionary<ÑharacterType, EnemiesPool> EnemiesPool => _enemiesPool;
        [Inject]
        private readonly PlayerControl _playerControl;

        [Inject]
        private readonly TilesManager _tilesManager;
        [Inject]
        private readonly Transform _enemiesContainer;
        private List<EnemiesSpawner> _unitSpawners = new();
        //todo Äîáàâèòü òàéìåğ ñïàâíà äëÿ êàæäîãî òèïà âğàãîâ
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
        /// Èíèöèàëèçàöèÿ ïóëà âğàãîâ
        /// </summary>
        private void InitEnemyPool()
        {
            _enemiesPool.Add(ÑharacterType.FastMeleeEnemy, new(Resources.Load<BaseEnemy>("Prefabs/Enemy/FirstEnemy/Enemy"), ÑharacterType.FastMeleeEnemy, _enemiesContainer, _playerControl, 2));
            _enemiesPool.Add(ÑharacterType.Spider, new(Resources.Load<BaseEnemy>("Prefabs/Enemy/Spiders/Prefabs/Black Widow 1"), ÑharacterType.Spider, _enemiesContainer, _playerControl, 2));
            //ïóë äëÿ áîññà
            //_enemiesPool.Add(ÑharacterType.Devil_Bulldog, new(Resources.Load<BossEnemy>("Prefabs/Enemy/BigBoss/DeepNest/Devil_Bulldog_Lite/EnemyBoss"), ÑharacterType.Devil_Bulldog, _enemiesContainer, _playerControl, 1));
        }
        /// <summary>
        /// Äëÿ òåñòà - ñïàâí íà êëàâèøó B
        /// </summary>
        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _timer = _enemySpawnCooldown;
                SpawnEnemyAtRandomTile();
            }
        }

        private void SpawnEnemyAtRandomTile()
        {

            BaseEnemy enemy = _enemiesPool[(ÑharacterType)UnityEngine.Random.Range(1,
                                                                                         Enum.GetNames(typeof(ÑharacterType)).Length)].GetAviableOrCreateNew();

            int randompoint = UnityEngine.Random.Range(0, _unitSpawners.Count());
            Tile_Marker parentTile = _unitSpawners[randompoint].GetComponentInParent<Tile_Marker>();
            //ïğîâåğêà, íå öåíòğàëüíûé ëè ıòî òàéë. â í¸ì íå ñïàâíèì

            while (_tilesManager.IsInMiddle(parentTile))
            {
                randompoint = UnityEngine.Random.Range(0, _unitSpawners.Count());
                parentTile = _unitSpawners[randompoint].GetComponentInParent<Tile_Marker>();
            }

            enemy.transform.position = _unitSpawners[randompoint].transform.position;
            enemy.GetComponent<BaseEnemy>().Respawn();
        }

        public List<BaseEnemy> FindAllEnemies()
        {
            List<BaseEnemy> enemies = EnemiesPool[ÑharacterType.FastMeleeEnemy].GetActiveUnits();
            enemies.AddRange(EnemiesPool[ÑharacterType.Spider].GetActiveUnits());
            return enemies;
        }
    }
}
