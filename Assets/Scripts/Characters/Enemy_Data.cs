using UnityEngine;

namespace TDShooter.Configs
{
    public class Enemy_Data : Character_Data
    {
        [SerializeField] private Character_UI _character_UI;
        private string _ratio_dificty = "Dificty";

        protected override void Awake()
        {
            base.Awake();
            SetDifficulty(HasKey(_ratio_dificty));
            _character_UI.SliderHP.maxValue = Hp;
            _character_UI.SliderHP.value = Hp;
        }
        public int HasKey(string KeyName)
        {
            if (PlayerPrefs.HasKey(KeyName))
            {
                return PlayerPrefs.GetInt(KeyName);
            }
            else
                return 1;
        }
    }
}