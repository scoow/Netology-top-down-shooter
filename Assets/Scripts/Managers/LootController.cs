using System.Collections.Generic;
using TDShooter.Configs;
using TDShooter.enums;
using TDShooter.Pools;
using UnityEngine;
using Zenject;

namespace TDShooter
{
    public class LootController : MonoBehaviour//todo �������� ��� ����
    {
        [SerializeField] private List<LootData_SO> _arreyLootData_SO;        

        public List<LootData_SO> Loots => _arreyLootData_SO;//������� readonlyList
        /// <summary>
        /// ���
        /// </summary>
        private readonly Dictionary<EffectType, LootPool> _lootPool = new();

        [Inject]
        private readonly LootContainer _lootContainer;
        private Transform _lootContainerTransform;

        private void Start()
        {
            _lootContainerTransform = _lootContainer.transform;
            //InitLootPool();
        }

        private void InitLootPool()
        {
            _lootPool.Add(EffectType.Health, new(Resources.Load<LootExample>("Prefabs/"), EffectType.Health, _lootContainerTransform));
        }
    }
}