using System;
using System.Collections.Generic;
using TDShooter.Configs;
using TDShooter.Enemies;
using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.Input;
using TDShooter.Level;
using TDShooter.UI;
using UnityEngine;
using Zenject;

namespace TDShooter.Characters
{
    public class Character_Player : Character
    {
        [Inject]
        private readonly SpawnAssistant _spawnAssistant;
        [Inject]
        private SubscribeManager _subscribeManager;
        [Inject]
        private TilesManager _tilesManager;

        public override void Die()
        {
            _subscribeManager.PostNotification(GameEventType.PlayerDied, null);
            print("Игра окончена , монстры вас съели");
            ControllPlayerOff();

            List<BaseEnemy> enemies = _spawnAssistant.FindAllEnemies();
            List<Transform> randomPositions = new();
            foreach (EnemiesSpawner spawner in _spawnAssistant.UnitSpawners)
            {
                randomPositions.Add(spawner.transform);
            }

            int i = 0;
            foreach (BaseEnemy enemy in enemies)
            {
                enemy.GetComponent<EnemyMove>().SetNewTarget(randomPositions[i]);
                i = i >= randomPositions.Count-1 ? 0 : ++i;
            }

        }

        private void ControllPlayerOff()
        {
            _tilesManager.DisableMoveRow();
            gameObject.GetComponent<Player_Data>().SpeedMove = 0f;
        }
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            _subscribeManager.PostNotification(GameEventType.PlayerScream, null);
        }
        private void Awake()
        {
            _character_Data = GetComponent<Character_Data>();
            _character_UI = GetComponent<Character_UI>();
        }
    }
}