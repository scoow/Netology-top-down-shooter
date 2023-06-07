using System.Collections;
using System.Collections.Generic;
using TDShooter.Configs;
using Unity.VisualScripting;
using UnityEngine;

public class ExtraWeaponDamage_Talent : Talents_Base
{
    public ExtraWeaponDamage_Talent(Player_Data player_Data) : base(player_Data)
    {
        Description = "Увеличенная скорострельность";
        TalentSprite = Resources.Load<Sprite>("Sprites/UI/Talents/Абилка_4");
    }
    public override void ActivateTalant()
    {

    }
}