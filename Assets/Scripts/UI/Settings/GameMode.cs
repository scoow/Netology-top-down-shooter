using System.Collections;
using System.Collections.Generic;
using TDShooter.Configs;
using UnityEngine;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    private float ratioGameMode;

    public Toggle Toggle { get => _toggle;}
    protected float RatioGameMode { get => ratioGameMode; set => ratioGameMode = value; }

    public virtual void SetParams()
    {
        PlayerPrefs.SetFloat(SettingsPanel_Marker._ratio_dificty, RatioGameMode);
        PlayerPrefs.Save();
        print($"Мы играем в режиме сложности {RatioGameMode}");
    }   
}