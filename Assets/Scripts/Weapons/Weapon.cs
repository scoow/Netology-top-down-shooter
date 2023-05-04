using TDShooter.enums;
using UnityEngine;
using Zenject;

namespace TDShooter.Weapons
{
    public class Weapon : MonoBehaviour
    {
        private ShootingPoint _shootingPoint;
        [Inject]
        private ProjectilesManager _projectilesManager;
        [SerializeField]
        private GameObject _bullet;
        private void Start()
        {
            _shootingPoint = GetComponentInChildren<ShootingPoint>();
            
        }
        public void Shoot()
        {
            var projectile = _projectilesManager._projectilePool[ProjectileType.Bullet].GetAviableOrCreateNew();
            projectile.transform.SetPositionAndRotation(_shootingPoint.transform.position, _shootingPoint.transform.rotation);
        }
    }
}