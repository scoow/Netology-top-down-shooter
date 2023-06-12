using TDShooter.Configs;
using TDShooter.enums;
using Unity.VisualScripting;
using UnityEngine;

namespace TDShooter.Talents
{
    public class NuclearCharge_Talent : Talents_Base
    {
        public NuclearCharge_Talent(Player_Data player_Data) : base(player_Data)
        {
            Description = "�����, ��������� ���� ������ �� ������";
            TalentSprite = Resources.Load<Sprite>("Sprites/UI/Talents/������_2");
        }
        public override void ActivateTalant()
        {
            //
        }
        public override TalentType GetTalantType() { return TalentType.NuclearCharge; }
    }
}