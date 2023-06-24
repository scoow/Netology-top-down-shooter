using System.Collections.Generic;
using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.Pools;
using UnityEngine;
using Zenject;

namespace TDShooter.Effects
{
    public class EffectController : MonoBehaviour, IEventListener
    {
        private readonly Dictionary<VisualEffectType, EffectPool> _effectsPool = new();

        [Inject]
        private readonly BloodstainContainer _bloodstainContainer;
        private Transform _bloodstainContainerTransform;

        private void Start()
        {
            _bloodstainContainerTransform = _bloodstainContainer.transform;
            InitBloodstainPool();
        }

        public void Spawn(Vector3 position)
        {
            BloodStain newBloodStain = _effectsPool[VisualEffectType.BloodStain].GetAviableOrCreateNew();
            position.y += 0.1f;
            newBloodStain.transform.position = position;
        }

        private void InitBloodstainPool()
        {
            _effectsPool.Add(VisualEffectType.BloodStain, new(Resources.Load<BloodStain>("Prefabs/BloodStain"), _bloodstainContainerTransform));//кровь
        }

        public void OnEvent(GameEventType eventType, Component sender, Object param = null)
        {
            Spawn(sender.transform.position);
        }
    }
}