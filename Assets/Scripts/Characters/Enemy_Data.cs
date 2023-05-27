using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Data : Character_Data
{
    [SerializeField] private Character_UI _character_UI;

    protected override void Awake()
    {
        base.Awake();
        _character_UI.SliderHP.maxValue = Hp;
        _character_UI.SliderHP.value = Hp;
    }

}