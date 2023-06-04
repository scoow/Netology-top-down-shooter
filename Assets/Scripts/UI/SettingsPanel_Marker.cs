using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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