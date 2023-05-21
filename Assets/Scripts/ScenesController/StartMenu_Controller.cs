using System;
using UnityEngine;
using UnityEngine.UI;


namespace TDShooter
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


        private void OnEnable()
        {
            _newGame.onClick.AddListener(delegate { LoadScene(SceneExample.NewGame); });
            _loadGame.onClick.AddListener(delegate { LoadNewGame(); });
            _settings.onClick.AddListener(delegate { LoadSettings(); });
            _exit.onClick.AddListener(delegate { LoadScene(SceneExample.Exit); });
            _return.onClick.AddListener(delegate { LoadStartMenu(); });
        }
       

        private void OnDisable()
        {
            _newGame.onClick.RemoveListener(delegate { LoadScene(SceneExample.NewGame); });
            _loadGame.onClick.RemoveListener(delegate { LoadNewGame(); });
            _settings.onClick.RemoveListener(delegate { LoadSettings(); });
            _exit.onClick.RemoveListener(delegate { LoadScene(SceneExample.Exit); });
        }
        private void LoadStartMenu()
        {
            _startPanel.gameObject.SetActive(true);
            _settingsPanel.gameObject.SetActive(false);           
        }

        private void LoadSettings() //заглушка
        {
            _startPanel.gameObject.SetActive(false);
            _settingsPanel.gameObject.SetActive(true);            
        }

        private void LoadNewGame() //заглушка
        {
            print("Загружаем игру");
        }

    }
}