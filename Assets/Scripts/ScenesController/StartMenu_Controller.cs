using UnityEngine;
using UnityEngine.UI;
using TDShooter.Configs;
using TDShooter.SaveLoad;
using TDShooter.enums;

namespace TDShooter.UI
{
    public class StartMenu_Controller : BaseUI_Controller
    {
        [SerializeField] private Button _newGame;
        [SerializeField] private Button _loadGame;
        [SerializeField] private Button _settings;
        [SerializeField] private Button _exit;
        [SerializeField] private Button _return;
        [SerializeField] private StartPanel_Marker _startPanel;
        [SerializeField] private SettingsPanel_Marker _settingsPanel;
        private LoadSaveManager _loadSaveManager;
        private void Start()
        {
            _loadSaveManager = FindObjectOfType<LoadSaveManager>();
        }
        private void OnEnable()
        {
            _newGame.onClick.AddListener(delegate { LoadScene(SceneExample.NewGame); });
            _loadGame.onClick.AddListener(delegate { LoadGame(); });
            _settings.onClick.AddListener(delegate { LoadSettings(); });
            _exit.onClick.AddListener(delegate { LoadScene(SceneExample.Exit); });
            _return.onClick.AddListener(delegate { LoadStartMenu(); });
        }

        private void OnDisable()
        {
            _newGame.onClick.RemoveListener(delegate { LoadScene(SceneExample.NewGame); });
            _loadGame.onClick.RemoveListener(delegate { LoadGame(); });
            _settings.onClick.RemoveListener(delegate { LoadSettings(); });
            _exit.onClick.RemoveListener(delegate { LoadScene(SceneExample.Exit); });
        }
        private void LoadStartMenu()
        {
            _startPanel.gameObject.SetActive(true);
            _settingsPanel.gameObject.SetActive(false);           
        }

        private void LoadGame()
        {
            print("Загружаем игру");
            _loadSaveManager.ResetProgress = false;
            LoadScene(SceneExample.NewGame);
        }

        private void LoadSettings() //заглушка
        {
            _startPanel.gameObject.SetActive(false);
            _settingsPanel.gameObject.SetActive(true);            
        }
    }
}