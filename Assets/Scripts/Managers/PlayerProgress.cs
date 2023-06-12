using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.SaveLoad;
using TDShooter.Level;
using TDShooter.UI;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace TDShooter.Managers
{
    public class PlayerProgress : MonoBehaviour, IEventListener, ISavable
    {
        [SerializeField] private int _levelCount; //счётчик уровней
        [SerializeField] private int _currentKillsCount; //текущие убийства 
        [SerializeField] private int _targetKillsCount; //колиичество убийств для повышения уровня
        [SerializeField] private int _lootDropChance; //шанс выпадения лута
        [SerializeField] private int _targetKillsMultiplier = 2;//множитель увеличения количества необходимых убийств
        [SerializeField] private Transform _teleport;
        [SerializeField] private Portal _portal;

        [Inject]
        private readonly UI_Controller _controllerUI;
        public int ChanceDroopLoot => _lootDropChance;

        public event UnityAction OnNextLevel;

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
                        GoToNextLevel();

                    }
                }
            }
        }

        private void GoToNextLevel()
        {
            _currentKillsCount = 0;
            _controllerUI.UpdateView(_currentKillsCount, UpdateViewType.TargetKills);
            _levelCount++;
            if (_levelCount == 5)
            {
                _portal.gameObject.SetActive(true);
            }
            _controllerUI.UpdateView(_levelCount, UpdateViewType.LevelUp);
            //_targetKillsCount *= _targetKillsMultiplier;//увеличить необходимое количество убийств
            _controllerUI.UpdateView(_targetKillsCount, UpdateViewType.TargetKills);

            OnNextLevel?.Invoke();
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

        public string SaveThis()
        {
            return _levelCount.ToString() + "," + _currentKillsCount.ToString();
        }

        public void LoadThis(string data)
        {
            string[] splittedData = data.Split(',');
            _levelCount = int.Parse(splittedData[0]);
            _currentKillsCount = int.Parse(splittedData[1]);
        }
    }
}
