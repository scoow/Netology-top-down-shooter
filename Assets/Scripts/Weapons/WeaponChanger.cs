using TDShooter.enums;
using UnityEngine;
using UnityEngine.UI;

namespace TDShooter.UI
{
    public class WeaponChanger : MonoBehaviour
    {
        [SerializeField] Image _currentWeaponImage;
        [SerializeField] Sprite _machineGunSprite;
        [SerializeField] Sprite _plasmaGunSprite;

        //[SerializeField] GameObject _currentWeaponModel;
        [SerializeField] GameObject _machineGun;
        [SerializeField] GameObject _plasmaGun;
        public void ChangeWeapon(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Machinegun:
                    _currentWeaponImage.sprite = _machineGunSprite;
                    _plasmaGun.SetActive(false);
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