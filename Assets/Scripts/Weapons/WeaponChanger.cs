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
        public void ChangeWeapon(WeaponType type)
        {
            switch (type)
            {
                case WeaponType.Machinegun:
                    _currentWeaponImage.sprite = _machineGunSprite;
                    break;
                case WeaponType.Plasmagun:
                    _currentWeaponImage.sprite = _plasmaGunSprite;
                    break;
            }
        }
    }
}