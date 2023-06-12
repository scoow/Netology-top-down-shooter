using System.Collections.Generic;
using TDShooter.Characters;
using UnityEngine;
using Zenject;

namespace TDShooter.Talents
{
    public class NuclearChargeEffect : MonoBehaviour
    {
        [Inject]
        private readonly SpawnAssistant _spawnAssistant;
        public void Activate()
        {
            List<BaseEnemy> enemies = _spawnAssistant.FindAllEnemies();
            foreach (var enemy in enemies)
            {
                var character = enemy.GetComponent<Character>();
                character.Die();
            }
        }
    }
}