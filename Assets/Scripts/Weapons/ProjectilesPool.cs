using TDShooter.Weapons;
using UnityEngine;

namespace TDShooter.Pools
{
    /// <summary>
    /// ��� ��� ��������
    /// </summary>
    public class ProjectilesPool : BasePool<Bullet>
    {
        public ProjectilesPool(Bullet prefab, Transform parent, int count = 1) : base(prefab, parent)
        {
            Init(count);
        }
        protected override Bullet GetCreated() => Object.Instantiate(_prefab);
    }
}