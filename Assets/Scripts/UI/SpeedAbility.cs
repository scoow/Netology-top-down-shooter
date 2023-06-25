using Cysharp.Threading.Tasks;
using System;
using TDShooter.Configs;
using TDShooter.Input;
using UnityEngine;

namespace TDShooter.UI
{
    public class SpeedAbility : Ability
    {
        [SerializeField] ParticleSystem _speedEffect;
        [SerializeField] Transform _player;
        [SerializeField] PlayerControl _playerControl;

        internal void ShowAbility(LootData_SO currentLootData_SO)
        {
            _speedEffect.gameObject.SetActive(true);
            SpeedRenderAsunc(currentLootData_SO);
        }

        private async void SpeedRenderAsunc(LootData_SO currentLootData_SO)
        {
            var timer = currentLootData_SO.EffectTime;
            await UniTask.Delay(Convert.ToInt32(1000 * timer));
            _speedEffect.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _playerControl.OnMove += RotateSpeedEffect;
        }

        private void OnDisable()
        {
            _playerControl.OnMove -= RotateSpeedEffect;
        }

        private void RotateSpeedEffect(Vector2 floatXZ)
        {
            Vector3 targetPos = new Vector3(_player.position.x - (floatXZ.x*1000) , 0, _player.position.z - (floatXZ.y*1000));  //магические числа         
            Quaternion rotation = Quaternion.LookRotation(targetPos, Vector3.up);            
            _speedEffect.transform.rotation = rotation;
        }
    }
}