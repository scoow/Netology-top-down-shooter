using UnityEngine;

namespace TDShooter.WinCondition
{
    /// <summary>
    /// Подсчёт убитых врагов
    /// </summary>
    public class EnemyKilledCounter
    {
        private int _count;
        public int GetCount => _count;
        public EnemyKilledCounter()
        {
            ResetCounter();
        }
        public void ResetCounter()
        {
            _count = 0;
        }
        public void Increment()
        {
            _count++;
            Debug.Log(_count);
        }
    }
}