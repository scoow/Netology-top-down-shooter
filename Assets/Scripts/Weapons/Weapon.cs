using TDShooter.Configs;
using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.UI;
using UnityEngine;
using Zenject;

namespace TDShooter.Weapons
{
    public class Weapon : MonoBehaviour, IDataSOLoader
    {
        [SerializeField] private WeaponData_SO _weaponData_SO;

        protected ShootingPoint _shootingPoint;
        [Inject]
        protected readonly ProjectilesManager _projectilesManager;
        [Inject]
        protected readonly WeaponChanger _weaponChanger;
        [Inject]
        protected readonly UI_Controller _controllerUI;

        private int _ammo = 9999;

        private string _weaponName;
        private Sprite _spriteWeapon;//добавить ссылку на спрайт в WeaponChanger
        private float _dropChance;
        private float _baseDamage;
        protected float _baseAccuracy;
        private float _rateOfFire;
        private float _maxAmmoCount;
        private ProjectileData_SO _projectileData;

        protected float _shootsCoolDown;
        protected float _shootTimer;
        private bool _isShooting;
        private float _shotSpread;
        private bool _haveSpread;
        [Inject]
        private readonly SubscribeManager _subscribeManager;

        /// <summary>
        /// Количество патронов
        /// </summary>
        protected int Ammo
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
            _haveSpread = true;
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
            _isShooting = true;
        }
        public void CancelShoot()
        {
            _isShooting = false;
        }

        protected virtual void CreateProjectile()
        {
            if (_shootTimer < 0)
            {
                _shootTimer = _shootsCoolDown;
                Bullet projectile = null;
                Ammo -= 1;
                _controllerUI.UpdateView(Ammo, UpdateViewType.UpdateAmmo);
                switch (_weaponChanger.CurrentWeaponType)//выбор типа снаряда
                {
                    case WeaponType.Machinegun:
                        projectile = _projectilesManager.ProjectilePool[ProjectileType.Bullet].GetAviableOrCreateNew();
                        break;
                    case WeaponType.Plasmagun:
                        projectile = _projectilesManager.ProjectilePool[ProjectileType.Plasma].GetAviableOrCreateNew();
                        break;
                    case WeaponType.Shothun:
                        projectile = _projectilesManager.ProjectilePool[ProjectileType.Bullet].GetAviableOrCreateNew();
                        Bullet[] projectiles = new Bullet[10];
                        for (int i = 0; i < projectiles.Length; i++)
                        {
                            projectiles[i] = _projectilesManager.ProjectilePool[ProjectileType.Bullet].GetAviableOrCreateNew();
                            float shothunSpread = 100 / _baseAccuracy;//коэффициент точности оружия
                            Quaternion shutgunInnacuracyQuaternion = Quaternion.Euler(Random.Range(0f, shothunSpread), Random.Range(0f, shothunSpread), Random.Range(0f, shothunSpread));//случайный кватернион для разброса

                            projectiles[i].transform.SetPositionAndRotation(_shootingPoint.transform.position, _shootingPoint.transform.rotation * shutgunInnacuracyQuaternion);
                        }    
                            
                        break;
                    default:
                        break;
                }
                
                _shotSpread = _haveSpread? 100 / _baseAccuracy : 1;//коэффициент точности оружия
                Quaternion innacuracyQuaternion = Quaternion.Euler(Random.Range(0f, _shotSpread), Random.Range(0f, _shotSpread), Random.Range(0f, _shotSpread));//случайный кватернион для разброса

                projectile.transform.SetPositionAndRotation(_shootingPoint.transform.position, _shootingPoint.transform.rotation * innacuracyQuaternion);

                _subscribeManager.PostNotification(enums.GameEventType.PlayShootSound, this);
            }
        }
        public void SetSpread(bool active)
        {
            _haveSpread = active;
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