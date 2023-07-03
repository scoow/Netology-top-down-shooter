using TDShooter.Characters;
using TDShooter.enums;
using TDShooter.EventManager;
using UnityEngine;
using Zenject;

namespace TDShooter.Enemies
{
    public class Boss_Controller : MonoBehaviour, IEventListener
    {
        private BossSpawnPoint _spawnPoint;
        [Inject]
        private readonly SpawnAssistant _spawnAssistant;

        private void OnEnable()
        {
            _spawnPoint = FindFirstObjectByType<BossSpawnPoint>();
        }

        private void ActivateBoss()
        {
            _spawnAssistant.SpawnEnemy(_spawnPoint.transform.position, ÑharacterType.Boss);
        }

        public void OnEvent(GameEventType eventType, Component sender, Object param = null)
        {
            ActivateBoss();
        }
    }
}