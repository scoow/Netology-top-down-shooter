using System.Collections.Generic;
using System.Linq;
using TDShooter.enums;
using TDShooter.Level;
using UnityEngine;

namespace TDShooter.Characters
{
    public class SpawnAssistant : MonoBehaviour
    {
        /// <summary>
        /// Пул юнитов
        /// </summary>
        private Dictionary<EnemyType, EnemiesPool> _enemiesPool = new();
        public Dictionary<EnemyType, EnemiesPool> EnemiesPool => _enemiesPool;

        private TilesManager _tilesManager;

        private Transform _enemiesContainer;

        private List<EnemiesSpawner> _unitSpawners = new();

        private void Start()
        {
            _enemiesContainer = FindObjectOfType<EnemiesContainer_Marker>().transform;
            _tilesManager = FindObjectOfType<TilesManager>();
            _unitSpawners = FindObjectsOfType<EnemiesSpawner>().ToList();

            InitEnemyPool();
        }
        /// <summary>
        /// Инициализация пула врагов
        /// </summary>
        private void InitEnemyPool()
        {
            _enemiesPool.Add(EnemyType.FastMelee, new(Resources.Load<BaseEnemy>("Prefabs/Enemy"), EnemyType.FastMelee, _enemiesContainer));
        }
        /// <summary>
        /// Для теста - спавн на клавишу B
        /// </summary>
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.B))
            {
                BaseEnemy enemy = _enemiesPool[EnemyType.FastMelee].GetAviableOrCreateNew();

                int randompoint = Random.Range(0, _unitSpawners.Count());
                Tile_Marker parentTile = _unitSpawners[randompoint].GetComponentInParent<Tile_Marker>();
                //проверка, не центральный ли это тайл. в нём не спавним

                while (_tilesManager.IsInMiddle(parentTile))
                {
                    randompoint = Random.Range(0, _unitSpawners.Count());
                    parentTile = _unitSpawners[randompoint].GetComponentInParent<Tile_Marker>();
                }

                enemy.transform.position = _unitSpawners[randompoint].transform.position;
            }    
                
        }
    }
}
