using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.SaveLoad;
using TDShooter.Level;
using TDShooter.UI;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;
using TDShooter.Talents;
using UnityEditor.Experimental.GraphView;

namespace TDShooter.Managers
{
    public class PlayerProgress : MonoBehaviour, IEventListener, ISavable
    {
        [SerializeField] private int _levelCount; //������� �������
        private int _currentKillsCount = 0; //������� �������� 
        [SerializeField] private int _targetKillsCount; //����������� ������� ��� ��������� ������
        [SerializeField] private int _lootDropChance; //���� ��������� ����
        [SerializeField] private int _targetKillsMultiplier = 1;//��������� ���������� ���������� ����������� �������        
        [SerializeField] private Portal _portal;
        [SerializeField] private int _levelWhenThePortalOpens;
        private bool _nuclearChargeIsActive = false;
        public bool NuclearChargeIsActive => _nuclearChargeIsActive;
        private UI_Controller _controllerUI;
        [Inject]
        private readonly NuclearChargeEffect _nuclearChargeEffect;
        [Inject]
        private readonly SubscribeManager _subscribeManager;
        public int ChanceDroopLoot => _lootDropChance;

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
                        //�������� ����� � ���� ����������
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
            if (_levelCount == _levelWhenThePortalOpens)
            {
                _portal.gameObject.SetActive(true);
                _subscribeManager.PostNotification(GameEventType.PortalOpened, null);
            }
            _controllerUI.UpdateView(_levelCount, UpdateViewType.LevelUp);
            _targetKillsCount *= _targetKillsMultiplier;//��������� ����������� ���������� �������
            _controllerUI.UpdateView(_targetKillsCount, UpdateViewType.TargetKills);

            _subscribeManager.PostNotification(GameEventType.PlayerLevelUp, null);
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

            _controllerUI = FindObjectOfType<UI_Controller>();

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

            _controllerUI = FindObjectOfType<UI_Controller>();

            _controllerUI.UpdateView(_levelCount, UpdateViewType.LevelUp);
            _controllerUI.UpdateView(_currentKillsCount, UpdateViewType.CurrentKills);
        }

        public void ActivateNuclearCharge()
        {
            _nuclearChargeIsActive = true;
        }
        public void UseNuclearCharge()
        {
            if (_nuclearChargeIsActive)
            {
                print("����� �����������");
                _nuclearChargeEffect.Activate();
                _nuclearChargeIsActive = false;
            }
            else
                print("����� �� �����");
        }
    }
}