using System.Collections;
using System.Collections.Generic;
using TDShooter.Configs;
using TDShooter.enums;
using Unity.VisualScripting;
using UnityEngine;

public class ExtraFireRate_Talent : Talents_Base
{
    public ExtraFireRate_Talent(Player_Data player_Data) : base(player_Data)
    {
        Description = "����������� ����";
        TalentSprite = Resources.Load<Sprite>("Sprites/UI/Talents/������_1");
    }
    public override void ActivateTalant()
    {
        Player_Data.Damage *= 2;
    }
    public override TalentType GetTalantType() { return TalentType.ExtraFireRate; }
}