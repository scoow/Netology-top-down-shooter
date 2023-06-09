using TDShooter.enums;
using UnityEngine;
using Zenject.SpaceFighter;

namespace TDShooter
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NewCharacter", order = 1)]
    public class СharacterData_SO : ScriptableObject
    {
        [SerializeField] private int _hp;
        [SerializeField] private int _damage;
        [SerializeField] private int _armor;
        [SerializeField] private float _speedMove;
        [SerializeField] private float _missChance;
        [SerializeField] private float _criticalDamageChance;        
        [SerializeField] private СharacterType _сharacterType;

        /// <summary>
        /// здоровье
        /// </summary>
        public int Health => _hp;
        /// <summary>
        /// броня
        /// </summary>
        public int Armor => _armor;
        /// <summary>
        /// скорость передвижения
        /// </summary>
        public float SpeedMove => _speedMove;
        /// <summary>
        /// шанс попадания(промаха)
        /// </summary>
        public float MissChance => _missChance;
        /// <summary>
        /// шанс нанесения критического удара
        /// </summary>
        public float CriticalDamageChance => _criticalDamageChance;
        /// <summary>
        /// тип персонажа
        /// </summary>
        public СharacterType CharacterType => _сharacterType;
        /// <summary>
        /// наносимый урон
        /// </summary>
        public int Damage { get => _damage; set => _damage = value; }
    }
}