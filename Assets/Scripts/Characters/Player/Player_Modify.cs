using Cysharp.Threading.Tasks;
using System;
using TDShooter.UI;
using UnityEngine;
using Zenject;

namespace TDShooter.Configs
{
    public class Player_Modify : MonoBehaviour
    {
        [SerializeField] private Ability_Controller _ability_Controller;
        [SerializeField] private Player_Data _playerData;
        [SerializeField] private Player_UI _player_UI;

        [Inject]
        private WeaponChanger _weaponChanger;

        public void TakeLoot(LootData_SO currentLootData_SO)
        {
            _ability_Controller.ResetAbilityTimeView(currentLootData_SO);
            switch (currentLootData_SO.EffectType)
            {
                case TDShooter.enums.EffectType.Health:
                    _ = ModifyHealth(currentLootData_SO);
                    break;
                case TDShooter.enums.EffectType.Armor:
                    _ = ModifyArmor(currentLootData_SO);
                    break;
                case TDShooter.enums.EffectType.MoveSpeed:
                    _ = ModifyMove(currentLootData_SO);
                    break;
                case TDShooter.enums.EffectType.MissChance:
                    _ = ModifyMissChance(currentLootData_SO);
                    break;
                case TDShooter.enums.EffectType.CriticalDamageChance:
                    break;
                case TDShooter.enums.EffectType.Weapon:
                    break;
            }
        }

        private async UniTask ModifyMissChance(LootData_SO currentLootData_SO)//������������ ��������
        {
            _weaponChanger.CurrentWeapon().SetSpread(false);
            await UniTask.Delay((int)currentLootData_SO.EffectTime * 1000);
            _weaponChanger.CurrentWeapon().SetSpread(true);
        }

        private async UniTask ModifyHealth(LootData_SO currentLootData) //������������ ��������
        {
            var timer = currentLootData.EffectTime;
            var hpBonus = Convert.ToInt32(currentLootData.EffectValue / currentLootData.EffectTime);
            while (timer > 0)
            {
                timer -= 1;

                _playerData.CurrentHP += hpBonus;
                if (_playerData.CurrentHP > _playerData.MaxHP) _playerData.CurrentHP = _playerData.MaxHP;//�������� �� Mathf.Clamp?

                _player_UI.UpdateViewHealth(hpBonus, true);
                await UniTask.Delay(1000);
            }
        }

        private async UniTask ModifyArmor(LootData_SO currentLootData)//������������ �����
        {
            _playerData.Armor += Convert.ToInt32(currentLootData.EffectValue);
            await UniTask.Delay(Convert.ToInt32(currentLootData.EffectTime * 1000));
            _playerData.Armor = _playerData.CharacterData_SO.Armor;
        }

        private async UniTask ModifyMove(LootData_SO currentLootData)//������������ ��������
        {
            _playerData.SpeedMove = currentLootData.EffectValue;
            await UniTask.Delay(Convert.ToInt32(currentLootData.EffectTime * 1000));
            _playerData.SpeedMove = _playerData.CharacterData_SO.SpeedMove;
        }
    }
}