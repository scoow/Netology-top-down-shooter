using TDShooter.enums;
using TDShooter.UI;
using UnityEngine;
namespace TDShooter.Weapons
{
    public class Shotgun : Weapon
    {
        protected override void CreateProjectile()
        {
            if (_shootTimer < 0)
            {
                _shootTimer = _shootsCoolDown;
                Bullet projectile = null;
                Ammo -= 1;
                _controllerUI.UpdateView(Ammo, UpdateViewType.UpdateAmmo);
                switch (_weaponChanger.CurrentWeaponType)//выбор типа снаряда ПЕРЕНЕСТИ В Projectile manager
                {
                    case WeaponType.Machinegun:
                        
                        break;
                    case WeaponType.Plasmagun:
                        projectile = _projectilesManager.ProjectilePool[ProjectileType.Plasma].GetAviableOrCreateNew();
                        break;
                    default:
                        break;
                }

                float shotSpread = 100 / _baseAccuracy;//коэффициент точности оружия
                Quaternion innacuracyQuaternion = Quaternion.Euler(Random.Range(0f, shotSpread), Random.Range(0f, shotSpread), Random.Range(0f, shotSpread));//случайный кватернион для разброса

                projectile.transform.SetPositionAndRotation(_shootingPoint.transform.position, _shootingPoint.transform.rotation * innacuracyQuaternion);
                //_isShooting = false;
            }
        }
    }
}