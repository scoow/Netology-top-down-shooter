using TDShooter.Configs;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.UI
{
    public class Ability_Controller : MonoBehaviour
    {
        [SerializeField] private Ability _speedView;
        [SerializeField] private Ability _armorView;
        [SerializeField] private Ability _glovesView;

        public async void ResetAbylityTimeView(LootData_SO currentLootData_SO)
        {
            switch (currentLootData_SO.EffectType)
            {
                case EffectType.SpeedMove:
                    await _speedView.ScaleTime(currentLootData_SO.EffectTime);
                    break;               
                case EffectType.Armor:
                    await _armorView.ScaleTime(currentLootData_SO.EffectTime);
                    break;
                case EffectType.MissChance:
                    await _glovesView.ScaleTime(currentLootData_SO.EffectTime);
                    break;                
            }
        }
    }
}