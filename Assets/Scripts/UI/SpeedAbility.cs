using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using TDShooter.Configs;
using TDShooter.UI;
using UnityEngine;
using Zenject;

namespace TDShooter
{
    public class SpeedAbility : Ability
    {
        [SerializeField] ParticleSystem _speedEffect;

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
    }
}