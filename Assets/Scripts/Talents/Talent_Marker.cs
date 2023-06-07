using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talent_Marker : MonoBehaviour
{
    //private int widhtSize = 230;
    //private int heightSize = 230;

    [SerializeField] Image _talentSprite;
    [SerializeField] Text _talentDescription;

    public void EnableTalantView(Talents_Base talents_Base)
    {
        _talentSprite.sprite = talents_Base.TalentSprite;
        _talentDescription.text = talents_Base.Description;
    }
}