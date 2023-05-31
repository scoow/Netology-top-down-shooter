using TDShooter.enums;
using UnityEngine;
using UnityEngine.UI;

namespace TDShooter.UI
{
    public class WeaponChanger : MonoBehaviour
    {
        public WeaponType CurrentWeaponType { get; private set; }
        [SerializeField] private Image _currentWeaponImage;
        [SerializeField] private Sprite _machineGunSprite;
        [SerializeField] private Sprite _plasmaGunSprite;

        [SerializeField] GameObject _machineGun;
        [SerializeField] GameObject _plasmaGun;
        private void Awake()
        {
            CurrentWeaponType = WeaponType.Machinegun;
        }
        /// <summary>
        /// Смена модельки и спрайта оружия
        /// </summary>
        /// <param name="type">новое оружие</param>
        public void ChangeWeapon(WeaponType type)
        {
            CurrentWeaponType = type;
            switch (type)
            {
                case WeaponType.Machinegun:
                    _currentWeaponImage.sprite = _machineGunSprite;
                    _plasmaGun.SetActive(false);//todo сделать массив оружия
                    _machineGun.SetActive(true);
                    break;
                case WeaponType.Plasmagun:
                    _currentWeaponImage.sprite = _plasmaGunSprite;
                    _machineGun.SetActive(false);
                    _plasmaGun.SetActive(true);
                    break;
            }
        }
    }
}