using TDShooter.Configs;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.Talents
{
    public class StoneSkin_Talent : Talents_Base
    {
        public StoneSkin_Talent(Player_Data player_Data) : base(player_Data)
        {
            Description = "�������������� �����";
            TalentSprite = Resources.Load<Sprite>("Sprites/UI/Talents/������_5");
        }
        public override void ActivateTalant()
        {
            Player_Data.Armor *= 2;
        }
        public override TalentType GetTalantType() { return TalentType.StoneSkin; }
    }
}