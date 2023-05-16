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
        private ProjectilesContainer_Marker _projectileContainer;
        public Dictionary<ProjectileType, ProjectilesPool> _projectilePool = new();

        private void Start()
        {
            InitProjectilesPools();
        }

        private void InitProjectilesPools()
        {
            _projectilePool.Add(ProjectileType.Bullet, new(Resources.Load<Bullet>("Prefabs/Bullet"), _projectileContainer.transform, 20));
            _projectilePool.Add(ProjectileType.Plasma, new(Resources.Load<Bullet>("Prefabs/Plasma"), _projectileContainer.transform, 20));
        }
    }
}