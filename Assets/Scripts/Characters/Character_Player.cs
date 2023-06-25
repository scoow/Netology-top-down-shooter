using System;
using System.Collections.Generic;
using TDShooter.Configs;
using TDShooter.Enemies;
using TDShooter.UI;
using UnityEngine;
using Zenject;

namespace TDShooter.Characters
{
    public class Character_Player : Character
    {
        [Inject]
        private readonly SpawnAssistant _spawnAssistant;

        public Action OnDie;
        public override void Die()
        {
            OnDie?.Invoke();
            print("Игра окончена , монстры вас съели");

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
        private void Awake()
        {
            _character_Data = GetComponent<Character_Data>();
            _character_UI = GetComponent<Character_UI>();
        }
    }
}