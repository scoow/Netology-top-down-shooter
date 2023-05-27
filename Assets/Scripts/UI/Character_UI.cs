using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_UI : MonoBehaviour
{
    [SerializeField] private Slider _sliderHP;    

    public Slider SliderHP { get => _sliderHP; set => _sliderHP = value; }   

    public void UpdateView(int damage)
    {
        _sliderHP.value -= damage;
    }
}