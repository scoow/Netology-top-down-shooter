using TDShooter.Characters;
using TDShooter.Enemies;
using TDShooter.enums;
using TDShooter.Input;
using UnityEngine;

namespace TDShooter.Pools
{

    public class LootPool : BasePool<LootExample>
    {
        EffectType _lootType;
        public LootPool(LootExample prefab, EffectType lootType, Transform parent, int count = 5) : base(prefab, parent)
        { 
            _lootType = lootType;
            Init(count);
        }
        protected override LootExample GetCreated()
        {
            LootExample lootExample = GameObject.Instantiate(_prefab);

            //передать параметры

            return lootExample;
        }

    }
}