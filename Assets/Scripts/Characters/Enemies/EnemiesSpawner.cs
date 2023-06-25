using UnityEngine;

namespace TDShooter.Characters
{
    public class EnemiesSpawner : MonoBehaviour
    {
        public bool Enabled { get; set; }

        private void Awake()
        {
            enabled = true;
        }
    }
}