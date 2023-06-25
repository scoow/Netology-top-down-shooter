using Cysharp.Threading.Tasks;
using System;
using System.Threading.Tasks;
using TDShooter.EventManager;
using TDShooter.Input;
using UnityEngine;
using Zenject;

namespace TDShooter.Level
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Vector3 _destinationPoint;
        [SerializeField] private float _delayBeforeTeleportation;
        [Inject] 
        private readonly SubscribeManager _subscribeManager;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<PlayerControl>(out var teleportTarget)) return;
            
            _ = TeleportAsync(teleportTarget);
        }

        private async Task TeleportAsync(PlayerControl teleportTarget)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_delayBeforeTeleportation));
            teleportTarget.transform.position = _destinationPoint;
            _subscribeManager.PostNotification(enums.GameEventType.PortalActivated, null);
        }
    }
}