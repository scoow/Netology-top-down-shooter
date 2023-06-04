using System.Linq;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.Pools
{

    public class LootPool : BasePool<LootExample>
    {
        private readonly LootController _lootController;

        readonly EffectType _lootType;
        public LootPool(LootExample prefab, EffectType lootType, Transform parent, LootController lootController, int count = 5) : base(prefab, parent)
        { 
            _lootType = lootType;
            _lootController = lootController;
            
            Init(count);
        }
        protected override LootExample GetCreated()
        {
            LootExample lootExample = GameObject.Instantiate(_prefab);

            //lootExample.Inject(_lootController);//передаём ссылку на контроллер
            lootExample.LoadLootData(_lootController.Loots.FirstOrDefault(x => x.EffectType == _lootType));

            return lootExample;
        }

    }
}