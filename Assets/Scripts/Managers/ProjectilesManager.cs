using System.Collections.Generic;
using TDShooter.enums;
using TDShooter.Pools;
using UnityEngine;
using Zenject;

namespace TDShooter.Weapons
{
    public class ProjectilesManager : MonoBehaviour
    {
        [Inject]
        private readonly ProjectilesContainer_Marker _projectileContainer;
        private readonly Dictionary<ProjectileType, ProjectilesPool> _projectilePool = new();
        private readonly Dictionary<GrenadeType, GrenadesPool> _grenadePool = new();

        public Dictionary<ProjectileType, ProjectilesPool> ProjectilePool => _projectilePool;
        public Dictionary<GrenadeType, GrenadesPool> GrenadePool => _grenadePool;

        private void Awake()
        {
            InitProjectilesPools();
            InitGrenadesPools();
        }
        /// <summary>
        /// Заполнение пула гранат
        /// </summary>
        private void InitGrenadesPools()
        {
            GrenadePool.Add(GrenadeType.Explosive, new(Resources.Load<Grenade>("Prefabs/Weapon/Grenade/Grenade Zaria/Prefabs/Zaria"), _projectileContainer.transform, 5));
        }

        /// <summary>
        /// Заполнение пула снарядов
        /// </summary>
        private void InitProjectilesPools()
        {
            ProjectilePool.Add(ProjectileType.Bullet, new(Resources.Load<Bullet>("Prefabs/Bullet"), _projectileContainer.transform, 20));
            ProjectilePool.Add(ProjectileType.Plasma, new(Resources.Load<Bullet>("Prefabs/Plasma"), _projectileContainer.transform, 20));
        }
    }
}