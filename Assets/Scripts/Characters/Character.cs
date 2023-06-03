using UnityEngine;
using TDShooter.Configs;

namespace TDShooter.Characters
{
    /// <summary>
    /// Персонаж. По задумке - класс-родитель для игрока и врагов
    /// </summary>
    public class Character : MonoBehaviour, IHaveHP
    {    
        [SerializeField] protected Character_Data _character_Data;
        [SerializeField] protected Character_UI _character_UI;        
        public int HP => _character_Data.Hp;        
       
        public virtual void Die()
        {
            print("Я погиб");          
        }
        public void TakeDamage(int damage)
        {
            int incomingDamage = damage - _character_Data.Armor;
            if (incomingDamage <= 0) return;
            _character_Data.CurrentHP -= incomingDamage;
            _character_UI.UpdateViewHealth(damage,false);
            //Debug.Log("HP осталось:" + _hp);
            if (_character_Data.CurrentHP <= 0)
                Die();
        }
        public void TakeHeal(int heal)
        {
            _character_Data.CurrentHP += heal;
            _character_UI.UpdateViewHealth(heal,true);
        }
    }
}