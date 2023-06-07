using System;
using System.Collections;
using System.Collections.Generic;
using TDShooter.Configs;
using TDShooter.enums;
using UnityEngine;

public class Talent_Controll : MonoBehaviour
{
    [SerializeField] Talent_Marker _talentOneView;
    [SerializeField] Talent_Marker _talentTwoView;
    [SerializeField] Player_Data _playerData;



    public void EnableTalent(Talents? talentOne, Talents? talentTwo) //зачем в параметрах рядом с типом вопрос ???
    {
        Talents_Base oneAccessibleTalant =  ChoiseTalant(talentOne);
        _talentOneView.EnableTalantView(oneAccessibleTalant);        
        Talents_Base twoAccessibleTalant = ChoiseTalant(talentTwo);
        _talentTwoView.EnableTalantView(twoAccessibleTalant);        
    }

    private Talents_Base ChoiseTalant(Talents? talentExample)
    {
        if      (talentExample == Talents.StoneSkin) return new StoneSkin_Talent(_playerData);
        else if (talentExample == Talents.Radar) return new Radar_Talent(_playerData);
        else if (talentExample == Talents.ExtraFireRate) return new ExtraFireRate_Talent(_playerData);
        else if (talentExample == Talents.ExtraWeaponDamage) return new ExtraWeaponDamage_Talent(_playerData);
        else if (talentExample == Talents.Drone) return new Drone_Talent(_playerData);
        else if (talentExample == Talents.NuclearCharge) return new NuclearCharge_Talent(_playerData);
        else return null;
    }
}