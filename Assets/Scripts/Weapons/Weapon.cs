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
        private readonly ProjectilesManager _projectilesManager;
        [Inject]
        private readonly WeaponChanger _weaponChanger;
        private void Start()
        {
            _shootingPoint = GetComponentInChildren<ShootingPoint>();
        }
        public void Shoot()
        {
            Bullet projectile = null;
            switch ((_weaponChanger.CurrentWeaponType))//выбор типа снаряда
            {
                case WeaponType.Machinegun:
                    projectile = _projectilesManager.ProjectilePool[ProjectileType.Bullet].GetAviableOrCreateNew();
                    break;
                case WeaponType.Plasmagun:
                    projectile = _projectilesManager.ProjectilePool[ProjectileType.Plasma].GetAviableOrCreateNew();
                    break;
                default:
                    break;
            }

            projectile.transform.SetPositionAndRotation(_shootingPoint.transform.position, _shootingPoint.transform.rotation);
        }
    }
}