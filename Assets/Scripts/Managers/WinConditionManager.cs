using TDShooter.WinCondition;
using UnityEngine;

namespace TDShooter.Managers
{
    /// <summary>
    /// ������������ ������� ������
    /// </summary>
    public class WinConditionManager : MonoBehaviour
    {
        private EnemyKilledCounter _enemyKilledCounter = new();
        private Timer _timer;
        private void Awake()
        {
            _timer = GetComponent<Timer>();//��������� �� ���� ������
        }
        private void Start()
        {
            _timer.ResetTimer();
        }
    }
}