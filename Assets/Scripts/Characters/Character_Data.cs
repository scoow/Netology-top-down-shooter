using System;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.Configs
{
    public class Character_Data : MonoBehaviour
    {
        [SerializeField] private ÑharacterData_SO _characterData_SO;
        private int _hp;
        private int _damage;
        private int _armor;
        private float _speedMove;
        private float _missChance;
        private float _criticalDamageChance;
        private ÑharacterType _ñharacterType;

        private int maxHP;
        private int currentHP;

        public int Hp { get => _hp; set => _hp = value; }
        public int Armor { get => _armor; set => _armor = value; }
        public float SpeedMove { get => _speedMove; set => _speedMove = value; }
        public float MissChance { get => _missChance; set => _missChance = value; }
        public float CriticalDamageChance { get => _criticalDamageChance; private set => _criticalDamageChance = value; }
        public ÑharacterType ÑharacterType { get => _ñharacterType; private set => _ñharacterType = value; }
        public ÑharacterData_SO CharacterData_SO { get => _characterData_SO; }
        public int Damage { get => _damage; set => _damage = value; }
        public int MaxHP { get => maxHP; set => maxHP = value; }
        public int CurrentHP { get => currentHP; set => currentHP = value; }

        protected virtual void Awake()
        {
            //SetDifficulty(1); // ïåğåäåëàòü íà êîíôèã ïåğåäàâàåìûé â ñöåíå 
        }

        protected void SetDifficulty(float ratio)
        {
            Hp = Convert.ToInt32(CharacterData_SO.Health * ratio);
            MaxHP = Hp;
            CurrentHP = Hp;
            Damage = Convert.ToInt32(CharacterData_SO.Damage * ratio);
            Armor = Convert.ToInt32(CharacterData_SO.Armor*ratio);
            SpeedMove = CharacterData_SO.SpeedMove;
            MissChance = CharacterData_SO.MissChance;
            CriticalDamageChance = CharacterData_SO.CriticalDamageChance* ratio;
            ÑharacterType = CharacterData_SO.CharacterType;
        }            
    }
}