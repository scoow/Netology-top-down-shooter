using TDShooter.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace TDShooter.UI
{
    public class Player_UI : Character_UI
    {
        [SerializeField] private Text _maxHP;
        [SerializeField] private Text _currentHP;
        [SerializeField] private Player_Data _playerData;
        public Slider SliderHP => _sliderHP;

        public Text MaxHP => _maxHP;
        public Text CurrentHP => _currentHP;

        public void SetHP(int hp)
        {
            _sliderHP.value = hp;
            _sliderHP.maxValue = hp;
            _sliderHP.value = hp;
            _maxHP.text = hp.ToString();
            _currentHP.text = hp.ToString();
        }

        public override void UpdateViewHealth(int addedValueHP, bool isPositive)
        {
            base.UpdateViewHealth(addedValueHP, isPositive);
            _currentHP.text = _playerData.CurrentHP.ToString();
            _maxHP.text = _playerData.MaxHP.ToString();
        }
    }
}