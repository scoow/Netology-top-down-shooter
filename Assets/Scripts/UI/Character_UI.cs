using UnityEngine;
using UnityEngine.UI;
using Zenject;

public abstract class Character_UI : MonoBehaviour
{
    [Inject]
    protected Slider _sliderHP;    

    public virtual void UpdateViewHealth(int addedValueHP, bool isPositive)
    {
        if (isPositive) _sliderHP.value += addedValueHP;
        else _sliderHP.value -= addedValueHP;
    }
}