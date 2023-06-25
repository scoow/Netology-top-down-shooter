using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TDShooter.UI
{
    public abstract class Character_UI : MonoBehaviour
    {
        [Inject]
        protected Slider _sliderHP;

        public virtual void UpdateViewHealth(int addedValueHP, bool isPositive)
        {
            if (isPositive) _sliderHP.value += addedValueHP;
            else _sliderHP.value -= addedValueHP;
        }
        public void HideSliderHP()
        {
            _sliderHP.gameObject.SetActive(false);
        }
        public void ShowSliderHP()
        {
            _sliderHP.gameObject.SetActive(true);
        }
    }
}