using TDShooter.Weapons;
using UnityEngine;

namespace TDShooter.Pools
{
    public class GrenadesPool : BasePool<Grenade>
    {
        public GrenadesPool(Grenade prefab, Transform parent, int count = 1) : base(prefab, parent)
        {
            Init(count);
        }
        protected override Grenade GetCreated() => Object.Instantiate(_prefab);
    }
}