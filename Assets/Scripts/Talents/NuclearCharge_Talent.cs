using System.Collections;
using System.Collections.Generic;
using TDShooter.Configs;
using TDShooter.enums;
using Unity.VisualScripting;
using UnityEngine;

public class NuclearCharge_Talent : Talents_Base
{
    public NuclearCharge_Talent(Player_Data player_Data) : base(player_Data)
    {
        Description = "�����, ��������� ���� ������ �� ������";
        TalentSprite = Resources.Load<Sprite>("Sprites/UI/Talents/������_2");
    }
    public override void ActivateTalant()
    {

    }
    public override Talents GetTalantType() { return Talents.NuclearCharge; }
}