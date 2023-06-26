using TDShooter.Weapons;
using UnityEngine.UI;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace TDShooter.Effects
{
    public class BloodLifeTimer : LifeTimer
    {
        private Image _image;
        private void Awake()
        {
            _image = GetComponentInChildren<Image>();
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            _image.color = new UnityEngine.Color(_image.color.r, _image.color.g, _image.color.b, 1);
        }

        protected override void Update()
        {
            _lifeTimeLeft -= Time.deltaTime;
            if (_lifeTimeLeft < 0)
                DeactivateAsync(10);
        }
        protected async void DeactivateAsync(float time)
        {
            _image.DOColor(new UnityEngine.Color(_image.color.r, _image.color.g, _image.color.b, 0), time);
            await UniTask.Delay(Convert.ToInt32(1000 * time));
            gameObject?.SetActive(false);
        }
    }
}