using TDShooter.Characters;
using TDShooter.EventManager;
using TDShooter.Level;
using TDShooter.UI;
using TDShooter.Weapons;
using UnityEngine;
using Zenject;

namespace TDShooter.Managers.GameManager
{
    public class GameManager : MonoInstaller
    {
        public static GameManager Instance { get; private set; }

        //private CreateTileField _createTileField;
        private TilesManager _tilesManager;
        private Transform _enemiesContainer;
        //private PlayerControl _playerControl;
        private Aim_Marker _aim_Marker;
        private ProjectilesContainer_Marker _projectileContainer;
        private ProjectilesManager _projectilesManager;
        private SubscribeManager _subscribeManager;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }

        public override void InstallBindings()
        {
            _enemiesContainer = FindObjectOfType<EnemiesContainer_Marker>().transform;
            _tilesManager = FindObjectOfType<TilesManager>();
            _aim_Marker = FindObjectOfType<Aim_Marker>();
            _projectileContainer = FindObjectOfType<ProjectilesContainer_Marker>();
            _projectilesManager = FindObjectOfType<ProjectilesManager>();
            _subscribeManager = FindObjectOfType<SubscribeManager>();

            /*            _createTileField = FindObjectOfType<CreateTileField>();

                        Container.BindInstance(_createTileField).AsSingle();*/
            Container.BindInstance(_enemiesContainer).AsSingle();
            Container.BindInstance(_tilesManager).AsSingle();
            Container.BindInstance(_aim_Marker).AsSingle();
            Container.BindInstance(_projectileContainer).AsSingle();
            Container.BindInstance(_projectilesManager).AsSingle();
            Container.BindInstance(_subscribeManager).AsSingle();
        }
    }
}