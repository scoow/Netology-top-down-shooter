using System.Collections.Generic;
using System.Linq;
using TDShooter.Configs;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.Talents
{
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
        public override TalentType GetTalantType() { return TalentType.Drone; }
    }
}