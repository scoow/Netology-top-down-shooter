using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_UI : MonoBehaviour
{
    [SerializeField] private Slider _sliderHP;
    [SerializeField] private RectTransform _hpBarTransform;

    public Slider SliderHP { get => _sliderHP; set => _sliderHP = value; }   

    public void UpdateView(int damage)
    {
        _sliderHP.value -= damage;
    }

    private void Update()
    {
        _hpBarTransform.LookAt(Camera.main.transform.position);
    }
}