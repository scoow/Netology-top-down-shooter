using System.Collections.Generic;
using System.Linq;
using TDShooter.enums;
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

        private Transform _enemiesContainer;

        private List<EnemiesSpawner> _unitSpawners = new();

        private void Start()
        {
            _enemiesContainer = FindObjectOfType<EnemiesContainer_Marker>().transform;

            _unitSpawners = FindObjectsOfType<EnemiesSpawner>().ToList();

            InitUnitsPools();
        }
        /// <summary>
        /// Инициализация пула юнитов
        /// </summary>
        private void InitUnitsPools()
        {
            _enemiesPool.Add(EnemyType.FastMelee, new(Resources.Load<BaseEnemy>("Prefabs/Enemy"), EnemyType.FastMelee, _enemiesContainer));
        }
        /// <summary>
        /// Для теста - спавн на клавиши R G B
        /// </summary>
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.B))
            {
                var enemy = _enemiesPool[EnemyType.FastMelee].GetAviableOrCreateNew();
                int randompoint = Random.Range(0, _unitSpawners.Count());
                enemy.transform.position = _unitSpawners[randompoint].transform.position;
            }    
                
        }
    }
}
