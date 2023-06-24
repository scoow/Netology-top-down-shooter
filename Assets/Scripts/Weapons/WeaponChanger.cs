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
        [SerializeField] private Sprite _machineGunSprite;
        [SerializeField] private Sprite _plasmaGunSprite;

        [SerializeField] GameObject _machineGun;
        [SerializeField] GameObject _plasmaGun;

        private readonly Dictionary<WeaponType, (GameObject, Sprite)> _weaponsDictionary = new();
        private void Awake()
        {
            //CurrentWeaponType = WeaponType.Machinegun;
            CurrentWeaponType = WeaponType.Shothun;
            _weaponsDictionary.Add(WeaponType.Shothun, (_machineGun, _machineGunSprite));
            _weaponsDictionary.Add(WeaponType.Machinegun, (_machineGun, _machineGunSprite));
            _weaponsDictionary.Add(WeaponType.Plasmagun, (_plasmaGun, _plasmaGunSprite));
        }
        /// <summary>
        /// Смена модельки и спрайта оружия
        /// </summary>
        /// <param name="type">новое оружие</param>
        public void ChangeWeapon(WeaponType type)
        {
            if (CurrentWeaponType == type) return;
            CurrentWeaponType = type;
            foreach (var weapon in _weaponsDictionary.Keys)
            {
                if (weapon == type)
                {
                    _weaponsDictionary[weapon].Item1.SetActive(true);
                    _lastWeaponImage.sprite = _currentWeaponImage.sprite;
                    _currentWeaponImage.sprite = _weaponsDictionary[weapon].Item2;
                }
                else
                {
                    _weaponsDictionary[weapon].Item1.SetActive(false);
                }    
            }
        }
        public Weapon CurrentWeapon()
        {
            return _weaponsDictionary[CurrentWeaponType].Item1.GetComponent<Weapon>();//переделать
        }
    }
}