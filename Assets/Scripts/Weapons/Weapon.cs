using TDShooter.enums;
using TDShooter.UI;
using UnityEngine;
using Zenject;

namespace TDShooter.Weapons
{
    public class Weapon : MonoBehaviour
    {
        private ShootingPoint _shootingPoint;
        [Inject]
        private ProjectilesManager _projectilesManager;
        [Inject]
        private WeaponChanger _weaponChanger;
        private void Start()
        {
            _shootingPoint = GetComponentInChildren<ShootingPoint>();
            
        }
        public void Shoot()
        {
            Bullet projectile = null;
            switch ((_weaponChanger.CurrentWeaponType))
            {
                case WeaponType.Machinegun:
                    projectile = _projectilesManager._projectilePool[ProjectileType.Bullet].GetAviableOrCreateNew();
                    break;
                case WeaponType.Plasmagun:
                    projectile = _projectilesManager._projectilePool[ProjectileType.Plasma].GetAviableOrCreateNew();
                    break;
                default:
                    break;
            }

            //
            
            projectile.transform.SetPositionAndRotation(_shootingPoint.transform.position, _shootingPoint.transform.rotation);
        }
    }
}