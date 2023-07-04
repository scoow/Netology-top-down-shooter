using TDShooter.Effects;
using UnityEngine;

namespace TDShooter.Pools
{
    public class EffectPool : BasePool<BloodStain>
    {

        public EffectPool(BloodStain prefab, Transform parent, int count = 40) : base(prefab, parent)
        {
            Init(count);
        }
        protected override BloodStain GetCreated()
        {
            BloodStain bloodStain = GameObject.Instantiate(_prefab);
            return bloodStain;
        }
    }
}