using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_UI : MonoBehaviour
{
    [SerializeField] private Slider _sliderHP;    

    public Slider SliderHP { get => _sliderHP;}   

    public virtual void UpdateViewHealth(int addedValueHP, bool isPositive)
    {
        if (isPositive) _sliderHP.value += addedValueHP;
        else _sliderHP.value -= addedValueHP;
    }
}