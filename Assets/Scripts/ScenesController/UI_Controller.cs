using TDShooter.enums;
using UnityEngine;
using UnityEngine.UI;

namespace TDShooter.UI
{
    public class UI_Controller : MonoBehaviour
    {
        [SerializeField] private Text _currentKills;
        [SerializeField] private Text _targetKills;
        [SerializeField] private Text _levelValue;
        [SerializeField] private Slider _progressBarValue;
        [SerializeField] private Text _currentAmmo;

        internal void UpdateView(int incomingValue, UpdateViewType viewType )
        {
            switch (viewType)
            {
                case UpdateViewType.CurrentKills:
                    _currentKills.text = incomingValue.ToString();
                    _progressBarValue.value = incomingValue;
                    break;
                case UpdateViewType.TargetKills:
                    _targetKills.text = incomingValue.ToString();
                    _progressBarValue.maxValue = incomingValue;
                    break;
                case UpdateViewType.LevelUp:
                    _levelValue.text = incomingValue.ToString();                    
                    break;
                case UpdateViewType.UpdateHP:
/*                    _player_UI.UpdateViewHealth(incomingValue);
                    CurrentHP.text = incomingValue.ToString();
                    _sliderHP.value -= incomingValue;*/
                    break;
                case UpdateViewType.UpdateAmmo:
                    _currentAmmo.text = incomingValue.ToString();
                    break;
            }
        }
    }
}