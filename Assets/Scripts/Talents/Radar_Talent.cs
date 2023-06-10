using System.Collections;
using System.Collections.Generic;
using TDShooter.Configs;
using Unity.VisualScripting;
using UnityEngine;

public class Radar_Talent : Talents_Base
{
    public Radar_Talent(Player_Data player_Data) : base(player_Data)
    {
        Description = "Миникарта, показывающая врагов";
        TalentSprite = Resources.Load<Sprite>("Sprites/UI/Talents/Абилка_6");
    }
    public override void ActivateTalant()
    {
        Player_Data.MiniMap.EnableMiniMap();
    }
}