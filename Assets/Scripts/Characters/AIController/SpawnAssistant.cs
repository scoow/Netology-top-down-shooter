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
        //todo �������� ������ ������ ��� ������� ���� ������
        [SerializeField]
        private float _enemySpawnCooldown = 2;
        private float _timer;

        private void Start()
        {
            _unitSpawners = FindObjectsOfType<EnemiesSpawner>().ToList();
            _timer = _enemySpawnCooldown;
            InitEnemyPool();
        }
        /// <summary>
        /// ������������� ���� ������
        /// </summary>
        private void InitEnemyPool()
        {
            _enemiesPool.Add(�haracterType.FastMeleeEnemy, new(Resources.Load<BaseEnemy>("Prefabs/Enemy/FirstEnemy/Enemy"), �haracterType.FastMeleeEnemy, _enemiesContainer));
        }
        /// <summary>
        /// ��� ����� - ����� �� ������� B
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
