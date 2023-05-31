using TDShooter.Characters;
using TDShooter.UI;
using UnityEngine;

namespace TDShooter.Configs
{
    public class Player_Data : Character_Data
    {
        [SerializeField] private UI_Controller _uI_Controller;
        [SerializeField] private Player_UI _playerUI;
        [SerializeField] private Character_Player _playerCharacter;

        protected override void Awake()
        {
            base.Awake();            
            _playerUI.SliderHP.maxValue = Hp;
            _playerUI.SliderHP.value = Hp;
            _playerUI.MaxHP.text = Hp.ToString();
            _playerUI.CurrentHP.text = Hp.ToString();
        }        
    }
}