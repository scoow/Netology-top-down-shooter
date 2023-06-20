using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.SaveLoad;
using TDShooter.Level;
using TDShooter.UI;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using UnityEngine.SceneManagement;
using TDShooter.Talents;

namespace TDShooter.Managers
{
    public class PlayerProgress : MonoBehaviour, IEventListener, ISavable
    {
        [SerializeField] private int _levelCount; //счЄтчик уровней
        [SerializeField] private int _currentKillsCount; //текущие убийства 
        [SerializeField] private int _targetKillsCount; //колиичество убийств дл€ повышени€ уровн€
        [SerializeField] private int _lootDropChance; //шанс выпадени€ лута
        [SerializeField] private int _targetKillsMultiplier = 1;//множитель увеличени€ количества необходимых убийств        
        [SerializeField] private Portal _portal;
        private bool _nuclearChargeIsActive = false;
        public bool NuclearChargeIsActive => _nuclearChargeIsActive;
        [Inject]
        private readonly UI_Controller _controllerUI;
        [Inject]
        private readonly NuclearChargeEffect _nuclearChargeEffect;
        public int ChanceDroopLoot => _lootDropChance;

        public event UnityAction OnNextLevel;
        public event UnityAction OnPortal;

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
                OnPortal?.Invoke();
            }
            _controllerUI.UpdateView(_levelCount, UpdateViewType.LevelUp);
            _targetKillsCount *= _targetKillsMultiplier;//увеличить необходимое количество убийств
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
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "StartMenu") return;

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

            _controllerUI.UpdateView(_levelCount, UpdateViewType.LevelUp);
            _controllerUI.UpdateView(_targetKillsCount, UpdateViewType.TargetKills);
        }

        public void ActivateNuclearCharge()
        {
            _nuclearChargeIsActive = true;
        }
        public void UseNuclearCharge()
        {
            if (_nuclearChargeIsActive)
            {
                print("«ар€д активирован");
                _nuclearChargeEffect.Activate();
                _nuclearChargeIsActive = false;
            }
            else
                print("«ар€д не готов");
            
        }
    }
}
