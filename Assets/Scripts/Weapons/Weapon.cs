using TDShooter.Configs;
using TDShooter.enums;
using TDShooter.UI;
using UnityEngine;
using Zenject;

namespace TDShooter.Weapons
{
    public class Weapon : MonoBehaviour, IDataSOLoader
    {
        [SerializeField] private WeaponData_SO _weaponData_SO;

        private ShootingPoint _shootingPoint;
        [Inject]
        private readonly ProjectilesManager _projectilesManager;
        [Inject]
        private readonly WeaponChanger _weaponChanger;
        [Inject]
        private readonly UI_Controller _controllerUI;

        private int _ammo = 9999;

        private string _weaponName;
        private Sprite _spriteWeapon;
        private float _dropChance;
        /* [SerializeField] private EffectType _effectType;*/
        /* [SerializeField] private float _effectValue;*/
        private float _baseDamage;
        private float _baseAccuracy;
        private float _rateOfFire;
        private float _maxAmmoCount;
        private PojectileData_SO _projectileData;

        private float _shootsCoolDown;
        private float _shootTimer;
        private bool _isShooting;

        /// <summary>
        /// Количество патронов
        /// </summary>
        private int Ammo
        {
            get => _ammo;
            set
            {
                _ammo--;
                Mathf.Clamp(_ammo, 0, _maxAmmoCount);
            }
        }
        private void Awake()
        {
            LoadData();
            _shootsCoolDown = 10 / _rateOfFire;
            _shootTimer = _shootsCoolDown;
        }
        private void Start()
        {
            _shootingPoint = GetComponentInChildren<ShootingPoint>();
        }
        private void Update()
        {
            _shootTimer -= Time.deltaTime;
            if (_isShooting && _ammo > 0)
                CreateProjectile();
        }
        public void Shoot()
        {
            _isShooting = !_isShooting;
        }

        private void CreateProjectile()
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
                        projectile = _projectilesManager.ProjectilePool[ProjectileType.Bullet].GetAviableOrCreateNew();
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

        public void LoadData()
        {
            _weaponName = _weaponData_SO.WeaponName;
            _spriteWeapon = _weaponData_SO.SpriteWeapon;
            _dropChance = _weaponData_SO.DropChance;

            _baseDamage = _weaponData_SO.BaseDamage;
            _rateOfFire = _weaponData_SO.RateOfFire;
            _baseAccuracy = _weaponData_SO.BaseAccuracy;

            _maxAmmoCount = _weaponData_SO.MaxAmmoCount;
            _projectileData = _weaponData_SO.ProjectileData;
        }
    }
}