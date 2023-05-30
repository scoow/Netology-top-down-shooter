using TDShooter.UI;
using UnityEngine;

namespace TDShooter.Configs
{
    public class Player_Data : Character_Data
    {
        [SerializeField] private UI_Controller _uI_Controller;

        protected override void Awake()
        {
            base.Awake();
            _uI_Controller.SliderHP.maxValue = Hp;
            _uI_Controller.SliderHP.value = Hp;
            _uI_Controller.MaxHP.text = Hp.ToString();
            _uI_Controller.CurrentHP.text = Hp.ToString();
        }
    }
}