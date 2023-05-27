using TDShooter.enums;
using TDShooter.EventManager;
using UnityEngine;


namespace TDShooter.Managers
{
    public class PlayerProgress : MonoBehaviour, IEventListener
    {
        [SerializeField] private int _levelCount; //счётчик уровней
        [SerializeField] private int _currentKillsCount; //текущие убийства 
        [SerializeField] private int _targetKillsCount; //колиичество убийств для повышения уровня
        [SerializeField] private int _chanceDroopLoot; //шанс выпадения лута
        [SerializeField] private UI_Controller _controllerUI;
        public int ChanceDroopLoot => _chanceDroopLoot;

        public int LevelCount { get; private set; }
        public int CurrentKilledCount
        {
            get => _currentKillsCount;
            set
            {
                if (value > 0)
                {
                    _currentKillsCount = value;
                    _controllerUI.UpdateView(_currentKillsCount, UpdateViewType.CurrentKills);
                    if (_currentKillsCount == _targetKillsCount)
                    {
                        //добавить паузу и меню статистики
                        _currentKillsCount = 0;
                        _controllerUI.UpdateView(_currentKillsCount, UpdateViewType.TargetKills);
                        _levelCount++;
                        _controllerUI.UpdateView(_levelCount, UpdateViewType.LevelUp);
                        _targetKillsCount *= 2;//увеличить необходимое уоличество убийств
                        _controllerUI.UpdateView(_targetKillsCount, UpdateViewType.TargetKills);

                    }
                }
            }
        }
        public int TargetKilledCount
        {
            get => _targetKillsCount;
            set
            {
                if (value > 0)
                {
                    _targetKillsCount = value;
                    _controllerUI.UpdateView(_targetKillsCount,UpdateViewType.TargetKills);
                }

            }
        }


        private void Start()
        {
            _controllerUI.UpdateView(0, UpdateViewType.CurrentKills);
            _controllerUI.UpdateView(_targetKillsCount, UpdateViewType.TargetKills);
        }


        public int CheckChance()
        {
            return Random.Range(0, 100);
        }

        public void OnEvent(GameEventType eventType, Component sender, Object param = null)
        {
            if (eventType != GameEventType.EnemyDied) return;
            CurrentKilledCount++;
        }
    }
}
