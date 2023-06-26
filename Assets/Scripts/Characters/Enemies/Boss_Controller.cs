using TDShooter.Characters;
using TDShooter.enums;
using TDShooter.EventManager;
using UnityEngine;
using Zenject;

namespace TDShooter.Enemies
{
    public class Boss_Controller : MonoBehaviour, IEventListener
    {
        //private Boss_Move _bossMove;
        private BossSpawnPoint _spawnPoint;
        [Inject]
        private readonly SpawnAssistant _spawnAssistant;

        private void OnEnable()
        {
            //_bossMove = FindObjectOfType<Boss_Move>();//ÔÂÂ‰ÂÎ‡Ú¸
            _spawnPoint = FindFirstObjectByType<BossSpawnPoint>();
            //_bossMove.gameObject.SetActive(false);
        }

        private void ActivateBoss()
        {
/*            _bossMove.gameObject.SetActive(true);
            //_spawnPoint*/
            _spawnAssistant.SpawnEnemy(_spawnPoint.transform.position, —haracterType.Boss);
        }

        public void OnEvent(GameEventType eventType, Component sender, Object param = null)
        {
            ActivateBoss();
        }
    }
}