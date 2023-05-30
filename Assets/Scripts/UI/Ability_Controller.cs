using TDShooter.Configs;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.UI
{
    public class Ability_Controller : MonoBehaviour
    {
        [SerializeField] private Ability _speed;
        [SerializeField] private Ability _armor;
        [SerializeField] private Ability _gloves;

        public void ResetAbylityTimeView(LootData_SO currentLootData_SO)
        {
            switch (currentLootData_SO.EffectType)
            {
                case EffectType.SpeedMove:
                    _speed.ScaleTime(currentLootData_SO.EffectTime);
                    break;               
                case EffectType.Armor:
                    _armor.ScaleTime(currentLootData_SO.EffectTime);
                    break;
                case EffectType.MissChance:
                    _gloves.ScaleTime(currentLootData_SO.EffectTime);
                    break;                
            }
        }
    }
}