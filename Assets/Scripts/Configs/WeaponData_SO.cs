using UnityEngine;

namespace TDShooter.Configs
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NewWeapon", order = 1)]
    public class WeaponData_SO : ScriptableObject
    {
        [SerializeField] private string _weaponName;
        [SerializeField] private Sprite _spriteWeapon;
        [SerializeField] private float _dropChance;
        [SerializeField] private float _baseDamage;//�� ������?
        [SerializeField] private float _baseAccuracy;
        [SerializeField] private float _rateOfFire;
        [SerializeField] private float _maxAmmoCount;
        [SerializeField] private ProjectileData_SO _projectileData;

        /// <summary>
        /// �������� ������
        /// </summary>
        public string WeaponName => _weaponName;
        /// <summary>
        /// ����������� ������
        /// </summary>
        public Sprite SpriteWeapon => _spriteWeapon;
        /// <summary>
        /// ���� ���������
        /// </summary>
        public float DropChance => _dropChance;
        public float BaseDamage => _baseDamage;
        public float RateOfFire => _rateOfFire;
        public float BaseAccuracy => _baseAccuracy;
        public float MaxAmmoCount => _maxAmmoCount;
        public ProjectileData_SO ProjectileData => _projectileData;
    }
}