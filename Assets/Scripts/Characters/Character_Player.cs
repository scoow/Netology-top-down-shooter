using System.Collections.Generic;
using TDShooter.Configs;
using TDShooter.Enemies;
using UnityEngine;
using Zenject;

namespace TDShooter.Characters
{
    public class Character_Player : Character
    {
        [Inject]
        private SpawnAssistant _spawnAssistant;
        public override void Die()
        {
            print("Игра окончена , монстры вас съели");

            List<BaseEnemy> enemies = _spawnAssistant.FindAllEnemies();
            List<Vector3> randomPositions = new();
            foreach (EnemiesSpawner spawner in _spawnAssistant.UnitSpawners)
            {
                randomPositions.Add(spawner.transform.position);
            }

            int i = 0;
            foreach (BaseEnemy enemy in enemies)
            {
                //enemy.GetComponent<EnemyMove>().SetNewTarget(randomPositions[i]);
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