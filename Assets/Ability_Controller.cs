using TDShooter.enums;
using UnityEngine;

namespace TDShooter
{
    public class Ability_Controller : MonoBehaviour
    {
        [SerializeField] private Ability _speed;
        [SerializeField] private Ability _armor;
        [SerializeField] private Ability _gloves;

        public void ResetAbylityTimeView(EffectType effectType, float effectTime)
        {
            switch (effectType)
            {
                case EffectType.SpeedMove:
                    _speed.ScaleTime(effectTime);
                    break;               
                case EffectType.Armor:
                    _armor.ScaleTime(effectTime);
                    break;
                case EffectType.MissChance:
                    _gloves.ScaleTime(effectTime);
                    break;                
            }
        }
    }
}