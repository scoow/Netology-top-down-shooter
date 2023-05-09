using UnityEngine;

namespace TDShooter.Configs
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NewWeapon", order = 1)]
    public class WeaponData_SO : ScriptableObject
    {
        [SerializeField] private string _weaponName;
        [SerializeField] private Sprite _spriteWeapon;
        [SerializeField] private float _dropChance;
        /* [SerializeField] private EffectType _effectType;*/
        /* [SerializeField] private float _effectValue;*/
        [SerializeField] private float _baseDamage;
        [SerializeField] private float _rateOfFire;
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
        public ProjectileData_SO ProjectileData => _projectileData;
    }
}