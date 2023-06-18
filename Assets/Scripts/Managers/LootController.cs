using System.Collections.Generic;
using TDShooter.Configs;
using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.Managers;
using TDShooter.Pools;
using UnityEngine;
using Zenject;

namespace TDShooter
{
    public class LootController : MonoBehaviour, IEventListener
    {
        [SerializeField] private List<LootData_SO> _arrayLootData_SO;
        [Inject]
        private readonly PlayerProgress _playerProgress;
        public List<LootData_SO> Loots => _arrayLootData_SO;//Сделать readonlyList
        /// <summary>
        /// Пул
        /// </summary>
        private readonly Dictionary<EffectType, LootPool> _lootPool = new();

        [Inject]
        private readonly LootContainer _lootContainer;
        private Transform _lootContainerTransform;

        private void Start()
        {
            _lootContainerTransform = _lootContainer.transform;
            InitLootPool();
        }

        public void SpawnRandomLoot(Vector3 position)
        {
            LootData_SO _currentLoot = _arrayLootData_SO[Random.Range(0, _arrayLootData_SO.Capacity)];
            EffectType effectType = _currentLoot.EffectType;
            LootExample newLoot = _lootPool[effectType].GetAviableOrCreateNew();
            newLoot.transform.position = position;
        }

        private void InitLootPool()
        {
            _lootPool.Add(EffectType.Health, new(Resources.Load<LootExample>("Prefabs/LootExample"), EffectType.Health, _lootContainerTransform, this));//аптечки
            _lootPool.Add(EffectType.MoveSpeed, new(Resources.Load<LootExample>("Prefabs/LootExample"), EffectType.MoveSpeed, _lootContainerTransform, this));//сапоги
            _lootPool.Add(EffectType.Armor, new(Resources.Load<LootExample>("Prefabs/LootExample"), EffectType.Armor, _lootContainerTransform, this));//броня
            _lootPool.Add(EffectType.MissChance, new(Resources.Load<LootExample>("Prefabs/LootExample"), EffectType.MissChance, _lootContainerTransform, this));//перчатки
        }

        public void OnEvent(GameEventType eventType, Component sender, Object param = null)
        {
            if (eventType != GameEventType.EnemyDied) return;
            //
            if (_playerProgress.CheckChance() < _playerProgress.ChanceDroopLoot)
            {
                SpawnRandomLoot(sender.transform.position);
            }
            
        }
    }
}