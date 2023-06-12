using TDShooter.Characters;
using TDShooter.EventManager;
using TDShooter.Input;
using TDShooter.Level;
using TDShooter.Pools;
using TDShooter.SaveLoad;
using TDShooter.Talents;
using TDShooter.UI;
using TDShooter.Weapons;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TDShooter.Managers.GameManager
{
    public class GameManager : MonoInstaller
    {
        private TilesManager _tilesManager;
        private Transform _enemiesContainer;
        private Aim_Marker _aim_Marker;
        private ProjectilesContainer_Marker _projectileContainer;
        private ProjectilesManager _projectilesManager;
        private SubscribeManager _subscribeManager;
        private WeaponChanger _weaponChanger;
        private PlayerControl _playerControl;
        private UI_Controller _controllerUI;
        private LootController _lootController;
        private LootContainer _lootContainer;
        private TalentsManager _talentsManager;
        private PlayerProgress _playerProgress;
        private Talent_Controller _talentControll;
        private Slider _sliderHP;
        private SpawnAssistant _spawnAssistant;
        private PauseMenu_Controller _pauseMenu_Controller;
        private NuclearChargeEffect _nuclearChargeEffect;
        /*        private void Awake()
                {
                    DontDestroyOnLoad(this.gameObject);
                }*/
        /// <summary>
        /// Внедрение зависимостей
        /// </summary>
        public override void InstallBindings()
        {
            #region Поиск ссылок на сцене

            _enemiesContainer = FindObjectOfType<EnemiesContainer_Marker>().transform;
            _tilesManager = FindObjectOfType<TilesManager>();
            _aim_Marker = FindObjectOfType<Aim_Marker>();
            _projectileContainer = FindObjectOfType<ProjectilesContainer_Marker>();
            _projectilesManager = FindObjectOfType<ProjectilesManager>();
            _subscribeManager = FindObjectOfType<SubscribeManager>();
            _weaponChanger = FindObjectOfType<WeaponChanger>();
            _playerControl = FindObjectOfType<PlayerControl>();
            _controllerUI = FindObjectOfType<UI_Controller>();
            _lootController = FindObjectOfType<LootController>();
            _lootContainer = FindObjectOfType<LootContainer>();
            _talentsManager = FindObjectOfType<TalentsManager>();
            _playerProgress = FindObjectOfType<PlayerProgress>();
            _talentControll = FindObjectOfType<Talent_Controller>();
            _sliderHP = FindObjectOfType<Slider>();
            _spawnAssistant = FindObjectOfType<SpawnAssistant>();
            _pauseMenu_Controller = FindObjectOfType<PauseMenu_Controller>();
            _nuclearChargeEffect = FindObjectOfType<NuclearChargeEffect>();

            #endregion
            #region Добавление ссылок в DI контейнер

            Container.BindInstance(_enemiesContainer).AsSingle();
            Container.BindInstance(_tilesManager).AsSingle();
            Container.BindInstance(_aim_Marker).AsSingle();
            Container.BindInstance(_projectileContainer).AsSingle();
            Container.BindInstance(_projectilesManager).AsSingle();
            Container.BindInstance(_subscribeManager).AsSingle();
            Container.BindInstance(_weaponChanger).AsSingle();
            Container.BindInstance(_playerControl).AsSingle();
            Container.BindInstance(_controllerUI).AsSingle();
            Container.BindInstance(_lootController).AsSingle();
            Container.BindInstance(_lootContainer).AsSingle();
            Container.BindInstance(_talentsManager).AsSingle();
            Container.BindInstance(_playerProgress).AsSingle();
            Container.BindInstance(_talentControll).AsSingle();
            Container.BindInstance(_sliderHP).AsSingle();
            Container.BindInstance(_spawnAssistant).AsSingle();
            Container.BindInstance(_pauseMenu_Controller).AsSingle();
            Container.BindInstance(_nuclearChargeEffect).AsSingle();
            
            #endregion
        }
    }
}