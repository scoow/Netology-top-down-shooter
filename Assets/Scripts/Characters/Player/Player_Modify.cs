using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TDShooter.Configs;
using TDShooter.UI;
using UnityEngine;
using Zenject.SpaceFighter;

public class Player_Modify : MonoBehaviour
{
    [SerializeField] private Ability_Controller _ability_Controller;
    [SerializeField] private Player_Data _playerData;
    [SerializeField] private Player_UI _player_UI;

    public void TakeLoot(LootData_SO currentLootData_SO)
    {
        _ability_Controller.ResetAbylityTimeView(currentLootData_SO);
        switch (currentLootData_SO.EffectType)
        {
            case TDShooter.enums.EffectType.Health:
                _ = ModifyHealt(currentLootData_SO);
                break;
            case TDShooter.enums.EffectType.Armor:
                ModifyArmor(currentLootData_SO);
                break;
            case TDShooter.enums.EffectType.SpeedMove:
                _ = ModifyMove(currentLootData_SO);
                break;
            case TDShooter.enums.EffectType.MissChance:
                break;
            case TDShooter.enums.EffectType.CriticalDamageChance:
                break;
            case TDShooter.enums.EffectType.Weapon:
                break;
        }        
    }


    private async Task ModifyHealt(LootData_SO currentLootData) //модифицируем здоровье
    {
        var timer = currentLootData.EffectTime;
        var hpBonus = Convert.ToInt32(currentLootData.EffectValue / currentLootData.EffectTime);
        while (timer > 0)
        {
            timer -= 1;

            _playerData.CurrentHP += hpBonus;
            _player_UI.UpdateViewHealth(hpBonus, true);
            await Task.Delay(500);
        }
    }

    
    private void ModifyArmor(LootData_SO currentLootData)//модифицируем броню
    {

    }

    private async Task ModifyMove(LootData_SO currentLootData)//модифицируем движение
    {
        _playerData.SpeedMove = currentLootData.EffectValue;
        await Task.Delay(Convert.ToInt32(currentLootData.EffectTime * 1000));
        _playerData.SpeedMove = _playerData.CharacterData_SO.SpeedMove;
    }
}