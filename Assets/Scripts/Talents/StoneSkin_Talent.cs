using System.Collections;
using System.Collections.Generic;
using TDShooter.Configs;
using Unity.VisualScripting;
using UnityEngine;

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
}