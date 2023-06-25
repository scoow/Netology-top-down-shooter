using TDShooter.UI;
using UnityEngine;

namespace TDShooter.Configs
{
    public class SettingsPanel_Marker : MonoBehaviour
    {
        public static readonly string _ratio_dificty = "Dificty";
        
        public void ChangeMode(GameMode gameMode)
        {
            if(!gameMode.Toggle.isOn) return;
            gameMode.SetParams();
        }
    }
}