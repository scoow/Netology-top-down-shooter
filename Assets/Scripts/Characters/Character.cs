using UnityEngine;
using TDShooter.Configs;
using System;
using TDShooter.UI;

namespace TDShooter.Characters
{
    /// <summary>
    /// Персонаж. По задумке - класс-родитель для игрока и врагов
    /// </summary>
    public abstract class Character : MonoBehaviour, IDamageble
    {    
        protected Character_Data _character_Data;
        protected Character_UI _character_UI;        
        public int HP => _character_Data.Hp;

        public Action OnHit;
        public virtual void Die()
        {
            print("Я погиб");          
        }
        public void TakeDamage(int damage)
        {
            int incomingDamage = damage - _character_Data.Armor;
            OnHit?.Invoke();
            if (incomingDamage <= 0) return;

            _character_Data.CurrentHP -= incomingDamage;
            if (_character_Data.CurrentHP < _character_Data.MaxHP)
            {
                _character_UI.ShowSliderHP();
            }
            _character_UI.UpdateViewHealth(damage, false);
            if (_character_Data.CurrentHP <= 0)
                Die();
        }
        public void TakeHeal(int heal)
        {
            _character_Data.CurrentHP += heal;
            _character_UI.UpdateViewHealth(heal, true);
        }
    }
}