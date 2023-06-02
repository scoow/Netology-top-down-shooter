using System.Collections.Generic;
using TDShooter.Characters;
using TDShooter.Configs;
using TDShooter.enums;
using TDShooter.Input;
using TDShooter.Pools;
using UnityEngine;

namespace TDShooter
{
    public class LootController : MonoBehaviour//todo добавить пул лута
    {
        [SerializeField] private List<LootData_SO> _arreyLootData_SO;        

        public List<LootData_SO> Loots => _arreyLootData_SO;
        /// <summary>
        /// Пул
        /// </summary>
        private readonly Dictionary<EffectType, LootPool> _lootPool = new();
        private Transform _lootContainer;

        private void Start()
        {
            _lootContainer = FindObjectOfType<LootContainer>().transform;
            InitLootPool();
        }

        private void InitLootPool()
        {
            _lootPool.Add(EffectType.Health, new(Resources.Load<LootExample>("Prefabs/"), EffectType.Health, _lootContainer));
        }
    }
}