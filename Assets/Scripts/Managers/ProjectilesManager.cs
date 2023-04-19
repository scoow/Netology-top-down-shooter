using System.Collections.Generic;
using TDShooter.enums;
using TDShooter.Pools;
using UnityEngine;

namespace TDShooter.Weapons
{
    public class ProjectilesManager : MonoBehaviour
    {
        private ProjectilesContainer_Marker _projectileContainer;
        public Dictionary<ProjectileType, ProjectilesPool> _projectilePool = new();
        private void Awake()
        {
            _projectileContainer = FindObjectOfType<ProjectilesContainer_Marker>();
        }

        private void Start()
        {
            InitProjectilesPools();
        }

        private void InitProjectilesPools()
        {
            _projectilePool.Add(ProjectileType.Bullet, new(Resources.Load<Bullet>("Prefabs/Bullet"), _projectileContainer.transform, 20));
        }
    }
}