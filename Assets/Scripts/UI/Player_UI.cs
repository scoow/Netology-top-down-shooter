using System.Collections;
using System.Collections.Generic;
using TDShooter.Characters;
using TDShooter.Configs;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI : Character_UI
{
    [SerializeField] private Text _maxHP;
    [SerializeField] private Text _currentHP;    
    [SerializeField] private Player_Data _playerData;

    public Text MaxHP { get => _maxHP; set => _maxHP = value; }
    public Text CurrentHP { get => _currentHP; set => _currentHP = value; }

    public override void UpdateViewHealth(int addedValueHP, bool isPositive)
    {
        base.UpdateViewHealth(addedValueHP, isPositive);
        _currentHP.text = _playerData.CurrentHP.ToString();
        _maxHP.text = _playerData.MaxHP.ToString();
    }    
}