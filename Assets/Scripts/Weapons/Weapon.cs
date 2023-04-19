using TDShooter.enums;
using UnityEngine;

namespace TDShooter.Weapons
{
    public class Weapon : MonoBehaviour
    {
        private ShootingPoint _shootingPoint;
        private ProjectilesManager _projectilesManager;
        [SerializeField]
        private GameObject _bullet;
        private void Start()
        {
            _shootingPoint = GetComponentInChildren<ShootingPoint>();
            _projectilesManager = FindAnyObjectByType<ProjectilesManager>();
        }
        public void Shoot()
        {
            //var projectile = Instantiate(_bullet, _shootingPoint.transform.position, _shootingPoint.transform.rotation);
            var projectile = _projectilesManager._projectilePool[ProjectileType.Bullet].GetAviableOrCreateNew();
            projectile.transform.SetPositionAndRotation(_shootingPoint.transform.position, _shootingPoint.transform.rotation);
        }
    }
}