using System.Collections;
using System.Collections.Generic;
using TDShooter.Characters;
using TDShooter.Configs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Drone_Talent : Talents_Base
{
    public Drone_Talent(Player_Data player_Data) : base(player_Data)
    {        
        Description = "Дрон-помощник";
        TalentSprite = Resources.Load<Sprite>("Sprites/UI/Talents/Абилка_3");
    }
    public override void ActivateTalant()
    {
        Player_Data.DroneAssist.EnableDrone();
    }
}