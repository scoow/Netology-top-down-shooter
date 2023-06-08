using UnityEngine;

namespace TDShooter.Configs
{
    public class Enemy_Data : Character_Data
    {
        private Enemy_UI _enemy_UI;        

        protected override void Awake()
        {
            base.Awake();
            SetDifficulty(HasKey(SettingsPanel_Marker._ratio_dificty));
            _enemy_UI = GetComponent<Enemy_UI>();

            
        }
        private void Start()
        {
            _enemy_UI.SetHp(Hp);
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