using System.Collections;
using System.Collections.Generic;
using TDShooter.Configs;
using Unity.VisualScripting;
using UnityEngine;

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
}