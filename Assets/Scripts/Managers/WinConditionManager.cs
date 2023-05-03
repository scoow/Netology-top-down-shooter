using TDShooter.WinCondition;
using Zenject;

namespace TDShooter.Managers
{
    /// <summary>
    /// ������������ ������� ������
    /// </summary>
    public class WinConditionManager : MonoInstaller
    {
        private EnemyKilledCounter _enemyKilledCounter;
        public override void InstallBindings()
        {
            _enemyKilledCounter = new EnemyKilledCounter();
            Container.BindInstance(_enemyKilledCounter).AsSingle();
        }
    }
}