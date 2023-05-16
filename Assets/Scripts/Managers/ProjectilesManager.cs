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

        public Dictionary<ProjectileType, ProjectilesPool> ProjectilePool => _projectilePool;

        private void Awake()
        {
            InitProjectilesPools();
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