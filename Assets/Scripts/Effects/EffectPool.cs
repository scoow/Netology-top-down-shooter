using TDShooter.Effects;
using UnityEngine;

namespace TDShooter.Pools
{
    public class EffectPool : BasePool<BloodStain>
    {

        public EffectPool(BloodStain prefab, Transform parent, int count = 20) : base(prefab, parent)
        {
            Init(count);
        }
        protected override BloodStain GetCreated()
        {
            BloodStain bloodStain = GameObject.Instantiate(_prefab);
            //bloodStain.gameObject.transform.SetPositionAndRotation(new Vector3(bloodStain.transform.position.x, 0.05f, bloodStain.transform.position.z), Quaternion.AngleAxis(90, Vector3.right));
            return bloodStain;
        }
    }
}