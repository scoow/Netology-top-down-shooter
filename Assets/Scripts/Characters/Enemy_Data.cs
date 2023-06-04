using UnityEngine;

namespace TDShooter.Configs
{
    public class Enemy_Data : Character_Data
    {
        [SerializeField] private Character_UI _character_UI;        

        protected override void Awake()
        {
            base.Awake();
            SetDifficulty(HasKey(SettingsPanel_Marker._ratio_dificty));
            _character_UI.SliderHP.maxValue = Hp;
            _character_UI.SliderHP.value = Hp;
        }
        public float HasKey(string KeyName)
        {
            if (PlayerPrefs.HasKey(KeyName))
            {
                return PlayerPrefs.GetFloat(KeyName);
            }
            else { return 1; }
        }
    }
}