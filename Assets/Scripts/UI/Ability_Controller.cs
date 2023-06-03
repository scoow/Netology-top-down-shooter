using TDShooter.Configs;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.UI
{
    public class Ability_Controller : MonoBehaviour
    {
        [SerializeField] private SpeedAbility _speedView;
        [SerializeField] private ArmorAbility _armorView;
        [SerializeField] private GlovesAbility _glovesView;

        public void ResetAbylityTimeView(LootData_SO currentLootData_SO)
        {
            switch (currentLootData_SO.EffectType)
            {
                case EffectType.SpeedMove:
                     _speedView.ScaleTime(currentLootData_SO.EffectTime);
                    break;               
                case EffectType.Armor:                    
                     _armorView.ScaleTime(currentLootData_SO.EffectTime);
                    _armorView.ShowAbility(currentLootData_SO);
                    break;
                case EffectType.MissChance:
                    _glovesView.ScaleTime(currentLootData_SO.EffectTime);
                    break;                
            }
        }
    }
}