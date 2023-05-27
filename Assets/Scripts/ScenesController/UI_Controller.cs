using UnityEngine;
using UnityEngine.UI;

namespace TDShooter
{
    public class UI_Controller : MonoBehaviour
    {
        [SerializeField] private Text _maxHP;
        [SerializeField] private Text _currentHP;
        [SerializeField] private Text _currentKills;
        [SerializeField] private Text _targetKills;
        [SerializeField] private Text _levelValue;
        [SerializeField] private Slider _progressBarValue;
        [SerializeField] private Slider _sliderHP;

        public Slider SliderHP { get => _sliderHP; set => _sliderHP = value; }
        public Text MaxHP { get => _maxHP; set => _maxHP = value; }
        public Text CurrentHP { get => _currentHP; set => _currentHP = value; }

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
                    //_currentHP.text = incomingValue.ToString();
                    //_maxHP.text = incomingValue.ToString();
                    break;
                case UpdateViewType.UpdateHP:
                    CurrentHP.text = incomingValue.ToString();
                    _sliderHP.value -= incomingValue;
                    break;
            }
        }
    }
    public enum UpdateViewType
    {
        CurrentKills,
        TargetKills,
        LevelUp,
        UpdateHP
    }
}