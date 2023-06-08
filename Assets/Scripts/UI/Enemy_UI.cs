using TDShooter.UI;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_UI : Character_UI
{
    //protected new Slider _sliderHP;
    [SerializeField] private RectTransform _hpBarTransform;
    public Slider SliderHP => _sliderHP; 
    protected void Awake()
    {
        _sliderHP = GetComponentInChildren<Slider>();//если это враг
        _hpBarTransform = GetComponentInChildren<EnemyHPBarMarker>().GetComponent<RectTransform>();
    }
    private void Update()
    {
        _hpBarTransform.LookAt(Camera.main.transform.position);
    }
    public void SetHp(int hp)
    {
        _sliderHP.maxValue = hp;
        _sliderHP.value = hp;
    }
}