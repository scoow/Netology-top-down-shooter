using TDShooter.enums;
using UnityEngine;
using Zenject.SpaceFighter;

namespace TDShooter
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NewCharacter", order = 1)]
    public class СharacterData_SO : ScriptableObject
    {
        [SerializeField] private GameObject _prefabCharacter;
        [SerializeField] private float _hp;
        [SerializeField] private float _armor;
        [SerializeField] private float _speedMove;
        [SerializeField] private float _missChance;
        [SerializeField] private float _criticalDamageChance;
        [SerializeField] private СharacterType _haracterType;

        /// <summary>
        /// префаб персонажа
        /// </summary>
        public GameObject PrefabCharacter => _prefabCharacter;
        /// <summary>
        /// здоровье
        /// </summary>
        public float Health => _hp;
        /// <summary>
        /// броня
        /// </summary>
        public float Armor => _armor;
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
        public СharacterType CharacterType => _haracterType;
    }
}