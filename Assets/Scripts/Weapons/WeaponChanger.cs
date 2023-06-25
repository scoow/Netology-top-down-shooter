using System;
using System.Collections.Generic;
using TDShooter.enums;
using TDShooter.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace TDShooter.UI
{
    public class WeaponChanger : MonoBehaviour
    {
        public WeaponType CurrentWeaponType { get; private set; }
        [SerializeField] private Image _currentWeaponImage;
        [SerializeField] private Image _lastWeaponImage;
        [SerializeField] private Image _nextWeaponImage;
        [SerializeField] private Sprite _machineGunSprite;
        [SerializeField] private Sprite _shotgunSprite;
        [SerializeField] private Sprite _plasmaGunSprite;
        [SerializeField] private Sprite _BFGSprite;
        [SerializeField] private Sprite _emptySprite;

        [SerializeField] GameObject _machineGun;
        [SerializeField] GameObject _shotgun;
        [SerializeField] GameObject _plasmaGun;
        [SerializeField] GameObject _BFGun;

        [SerializeField]
        private float _UIShowTimer;
        private float _timer;

        private readonly List<(WeaponType, GameObject, Sprite)> _weaponsList = new();
        private void Awake()
        {
            CurrentWeaponType = WeaponType.Machinegun;

            _weaponsList.Add((WeaponType.Machinegun, _machineGun, _machineGunSprite));
            _weaponsList.Add((WeaponType.Shothun, _shotgun, _shotgunSprite));
            _weaponsList.Add((WeaponType.Plasmagun, _plasmaGun, _plasmaGunSprite));
            _weaponsList.Add((WeaponType.BFG, _BFGun, _BFGSprite));

            HideOrShowNextAndPrevWeaponSprites(false);
        }
        /// <summary>
        /// Смена модельки и спрайта оружия
        /// </summary>
        /// <param name="type">новое оружие</param>
        public void ChangeWeapon(WeaponType type)
        {
            if (CurrentWeaponType == type) return;
            CurrentWeaponType = type;

            foreach ((WeaponType, GameObject, Sprite) weapon in _weaponsList)
            {
                if (weapon.Item1 == type)
                {
                    weapon.Item2.SetActive(true);
                    _currentWeaponImage.sprite = weapon.Item3;
                }
                else
                {
                    weapon.Item2.SetActive(false);
                }
            }
            WeaponType previousWeapon, nextWeapon;
            previousWeapon = CurrentWeaponType - 1;
            if ((int)previousWeapon >= 0)
            {
                _lastWeaponImage.sprite = _weaponsList.Find(x => x.Item1 == previousWeapon).Item3;
            }
            else
            {
                _lastWeaponImage.sprite = _emptySprite;
            }
            nextWeapon = CurrentWeaponType + 1;
            if ((byte)nextWeapon < _weaponsList.Count)
            {
                _nextWeaponImage.sprite = _weaponsList.Find(x => x.Item1 == nextWeapon).Item3;
            }
            else
            {
                _nextWeaponImage.sprite = _emptySprite;
            }
            HideOrShowNextAndPrevWeaponSprites(true);
        }
        public Weapon CurrentWeapon()
        {
            return _weaponsList.Find(x => x.Item1 == CurrentWeaponType).Item2.GetComponent<Weapon>();
        }

        public void NextWeapon(float value)
        {
            if (value > 0)
            {
                if ((int)CurrentWeaponType > 0)
                    ChangeWeapon(CurrentWeaponType - 1);

            }
            else
            {
                if ((int)CurrentWeaponType < _weaponsList.Count - 1)
                    ChangeWeapon(CurrentWeaponType + 1);
            }
        }
        private void Update()
        {
            _timer -= Time.deltaTime;
            if ( _timer < 0 )
            {
                HideOrShowNextAndPrevWeaponSprites(false);
            }
        }

        private void HideOrShowNextAndPrevWeaponSprites(bool value)
        {
            _lastWeaponImage.enabled = value;
            _nextWeaponImage.enabled = value;
            if (value)
                _timer = _UIShowTimer;
        }
    }
}