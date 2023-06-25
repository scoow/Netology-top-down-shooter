using DG.Tweening;
using TDShooter.Audio;
using TDShooter.Characters;
using TDShooter.Effects;
using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.Input;
using TDShooter.Level;
using TDShooter.Pools;
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
        private BloodstainContainer _bloodstainContainer;
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
        private AudioController _audioController;
        private EffectController _effectController;
        private Boss_Controller _bossController;
        private DroneAssist _droneAssist;

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
            _bloodstainContainer = FindObjectOfType<BloodstainContainer>();
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
            _audioController = FindObjectOfType<AudioController>();
            _effectController = FindObjectOfType<EffectController>();
            _bossController = FindObjectOfType<Boss_Controller>();
            _droneAssist = FindObjectOfType<DroneAssist>();

            #endregion
            #region Добавление ссылок в DI контейнер

            Container.BindInstance(_enemiesContainer).AsSingle();
            Container.BindInstance(_tilesManager).AsSingle();
            Container.BindInstance(_aim_Marker).AsSingle();
            Container.BindInstance(_projectileContainer).AsSingle();
            Container.BindInstance(_bloodstainContainer).AsSingle();
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
            Container.BindInstance(_audioController).AsSingle();
            Container.BindInstance(_effectController).AsSingle();
            Container.BindInstance(_bossController).AsSingle();

            SubscribeToEvents();
            //начальные параметры для DOTween
            DOTween.SetTweensCapacity(4000, 50);
            #endregion
        }
        /// <summary>
        /// Подписки в SubscribeManager
        /// </summary>
        private void SubscribeToEvents()
        {
            _subscribeManager.AddListener(GameEventType.PlayShootSound, _audioController, true);
            _subscribeManager.AddListener(GameEventType.PlayStepSound, _audioController, true);

            _subscribeManager.AddListener(GameEventType.EnemySpawned, _audioController, true);
            _subscribeManager.AddListener(GameEventType.EnemyAttacked, _audioController, true);
            _subscribeManager.AddListener(GameEventType.EnemyDied, _audioController, true);

            _subscribeManager.AddListener(GameEventType.PlayerLevelUp, _spawnAssistant, true);

            _subscribeManager.AddListener(enums.GameEventType.EnemyDied, _playerProgress, true);
            //добавляем _playerProgress в слушатели события "смерть врага", параметр true означает что добавляем лишь один раз  
            _subscribeManager.AddListener(enums.GameEventType.EnemyDied, _lootController, true);
            _subscribeManager.AddListener(enums.GameEventType.EnemyDied, _effectController, true);

            _subscribeManager.AddListener(enums.GameEventType.PortalActivated, _bossController, true);
            _subscribeManager.AddListener(enums.GameEventType.PortalActivated, _spawnAssistant, true);
            _subscribeManager.AddListener(enums.GameEventType.EnemyDied, _droneAssist, true);
            

        }
    }
}