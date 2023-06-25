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
        /// Ïóë şíèòîâ
        /// </summary>
        private readonly Dictionary<ÑharacterType, EnemiesPool> _enemiesPool = new();
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
        public List<EnemiesSpawner> UnitSpawners => _unitSpawners;//ïåğåäåëàòü íà enumerable

        [SerializeField]
        private float _enemySpawnCooldown = 2;
        [SerializeField, Range(1, 2)]
        private float _SpawnLoodownReductionCoefficient;//êàæäûé óğîâåíü óìåíüøàåò âğåìÿ ìåæäó ïîÿâëåíèåì âğàãîâ
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
        /// Èíèöèàëèçàöèÿ ïóëà âğàãîâ
        /// </summary>
        private void InitEnemyPool()
        {
            _enemiesPool.Add(ÑharacterType.FastMeleeEnemy, new(Resources.Load<BaseEnemy>("Prefabs/Enemy/FirstEnemy/Enemy"), ÑharacterType.FastMeleeEnemy, _enemiesContainer, _playerControl, _subscribeManager, 2));
            _enemiesPool.Add(ÑharacterType.Spider, new(Resources.Load<BaseEnemy>("Prefabs/Enemy/Spiders/Prefabs/Black Widow 1"), ÑharacterType.Spider, _enemiesContainer, _playerControl, _subscribeManager, 2));
            _enemiesPool.Add(ÑharacterType.BossAssistant, new(Resources.Load<BaseEnemy>("Prefabs/Enemy/FirstEnemy/Enemy_Assist"), ÑharacterType.BossAssistant, _enemiesContainer, _playerControl, _subscribeManager, 2));
            
            //ïóë äëÿ áîññà
            //_enemiesPool.Add(ÑharacterType.Devil_Bulldog, new(Resources.Load<BossEnemy>("Prefabs/Enemy/BigBoss/DeepNest/Devil_Bulldog_Lite/EnemyBoss"), ÑharacterType.Devil_Bulldog, _enemiesContainer, _playerControl, 1));
        }
        /// <summary>
        /// Ñïàâí ïî òàéìåğó
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

            BaseEnemy enemy = _enemiesPool[(ÑharacterType)UnityEngine.Random.Range(1,Enum.GetNames(typeof(ÑharacterType)).Length-1)].GetAviableOrCreateNew();

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
        public void SpawnEnemy(Vector3 position, ÑharacterType ñharacterType)
        {
            BaseEnemy enemy = _enemiesPool[ñharacterType].GetAviableOrCreateNew();
            enemy.transform.position = position;
        }
        public List<BaseEnemy> FindAllEnemies()
        {
            List<BaseEnemy> enemies = _enemiesPool[ÑharacterType.FastMeleeEnemy].GetActiveUnits();
            enemies.AddRange(_enemiesPool[ÑharacterType.Spider].GetActiveUnits());
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
                    if (_enemySpawnCooldown < 0.5f)
                        _enemySpawnCooldown = 0.5f;
                    //îãğàíè÷èëè âğåìÿ ñïàâíà ìèíèìóìîì â 0.5 ñåê
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