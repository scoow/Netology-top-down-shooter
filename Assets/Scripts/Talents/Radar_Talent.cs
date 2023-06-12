using TDShooter.Configs;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.Talents
{
    public class Radar_Talent : Talents_Base
    {
        public Radar_Talent(Player_Data player_Data) : base(player_Data)
        {
            Description = "���������, ������������ ������";
            TalentSprite = Resources.Load<Sprite>("Sprites/UI/Talents/������_6");
        }
        public override void ActivateTalant()
        {
            Player_Data.MiniMap.EnableMiniMap();
        }
        public override TalentType GetTalantType() { return TalentType.Radar; }
    }
}