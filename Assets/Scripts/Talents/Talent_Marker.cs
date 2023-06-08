using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Talent_Marker : MonoBehaviour , IPointerClickHandler
{   

    [SerializeField] Image _talentSprite;
    [SerializeField] Text _talentDescription;
    [SerializeField] Talent_Marker _otherTalent;

    public void EnableTalantView(Talents_Base talents_Base)
    {
        _talentSprite.sprite = talents_Base.TalentSprite;
        _talentDescription.text = talents_Base.Description;
        transform.DOScale(Vector3.one, 0.5f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _otherTalent.transform.DOScale(Vector3.zero, 0.5f);          
        transform.DOScale(Vector3.zero, 0.5f);
    }
}