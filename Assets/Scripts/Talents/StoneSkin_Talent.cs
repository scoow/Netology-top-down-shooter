using TDShooter.Configs;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.Talents
{
    public class StoneSkin_Talent : Talents_Base
    {
        public StoneSkin_Talent(Player_Data player_Data) : base(player_Data)
        {
            Description = "Дополнительная броня";
            TalentSprite = Resources.Load<Sprite>("Sprites/UI/Talents/Абилка_5");
        }
        public override void ActivateTalant()
        {
            Player_Data.Armor *= 2;
        }
        public override TalentType GetTalantType() { return TalentType.StoneSkin; }
    }
}