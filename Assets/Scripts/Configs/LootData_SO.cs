using TDShooter.enums;
using UnityEngine;

namespace TDShooter.Configs
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NewLoot", order = 1)]
    public class LootData_SO : ScriptableObject
    {
        [SerializeField] private string _lootName;
        [SerializeField] private Sprite _spriteLoot;
        [SerializeField] private float _dropChance;        
        [SerializeField] private EffectType _effectType;
        [SerializeField] private float _effectValue;

        /// <summary>
        /// название добычи
        /// </summary>
        public string LootName => _lootName;
        /// <summary>
        /// изображение добычи
        /// </summary>
        public Sprite SpriteLoot => _spriteLoot;
        /// <summary>
        /// шанс выпадения
        /// </summary>
        public float DropChance => _dropChance;
        /// <summary>
        /// получаемый эффект
        /// </summary>
        public EffectType EffectType => _effectType;
        /// <summary>
        /// числовое значение эффекта
        /// </summary>
        public float EffectValue => _effectValue;
    }   
}