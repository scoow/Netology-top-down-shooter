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
        /// �������� ������
        /// </summary>
        public string LootName => _lootName;
        /// <summary>
        /// ����������� ������
        /// </summary>
        public Sprite SpriteLoot => _spriteLoot;
        /// <summary>
        /// ���� ���������
        /// </summary>
        public float DropChance => _dropChance;
        /// <summary>
        /// ���������� ������
        /// </summary>
        public EffectType EffectType => _effectType;
        /// <summary>
        /// �������� �������� �������
        /// </summary>
        public float EffectValue => _effectValue;
    }   
}