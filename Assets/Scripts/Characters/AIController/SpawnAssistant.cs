using System.Collections.Generic;
using System.Linq;
using TDShooter.enums;
using TDShooter.Level;
using TDShooter.WinCondition;
using UnityEngine;
using Zenject;

namespace TDShooter.Characters
{
    public class SpawnAssistant : MonoBehaviour
    {
        /// <summary>
        /// ��� ������
        /// </summary>
        private readonly Dictionary<�haracterType, EnemiesPool> _enemiesPool = new();
        public Dictionary<�haracterType, EnemiesPool> EnemiesPool => _enemiesPool;

        [Inject]
        private readonly TilesManager _tilesManager;
        [Inject]
        private readonly Transform _enemiesContainer;
        private List<EnemiesSpawner> _unitSpawners = new();

        [Inject]
        private readonly EnemyKilledCounter _enemyKilledCounter;

        //todo �������� ������ ������ ��� ������� ���� ������

        private void Start()
        {
            _unitSpawners = FindObjectsOfType<EnemiesSpawner>().ToList();

            InitEnemyPool();
        }
        /// <summary>
        /// ������������� ���� ������
        /// </summary>
        private void InitEnemyPool()
        {
            _enemiesPool.Add(�haracterType.FastMeleeEnemy, new(Resources.Load<BaseEnemy>("Prefabs/Enemy"), �haracterType.FastMeleeEnemy, _enemiesContainer, _enemyKilledCounter));
        }
        /// <summary>
        /// ��� ����� - ����� �� ������� B
        /// </summary>
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.B))
            {
                BaseEnemy enemy = _enemiesPool[�haracterType.FastMeleeEnemy].GetAviableOrCreateNew();

                int randompoint = Random.Range(0, _unitSpawners.Count());
                Tile_Marker parentTile = _unitSpawners[randompoint].GetComponentInParent<Tile_Marker>();
                //��������, �� ����������� �� ��� ����. � �� �� �������

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
