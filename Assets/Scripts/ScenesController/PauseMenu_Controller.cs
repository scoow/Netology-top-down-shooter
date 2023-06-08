using UnityEngine;
using UnityEngine.UI;

namespace TDShooter.UI
{
    public class PauseMenu_Controller : BaseUI_Controller
    {
        [SerializeField] private PauseMenu_Marker _pauseMenu;

        [SerializeField] private Button _resume;
        [SerializeField] private Button _saveGame;
        [SerializeField] private Button _mainMenu;
        [SerializeField] private Button _exit;

        private void OnEnable()
        {
            _resume.onClick.AddListener(delegate { ResumeGame(); });
            _saveGame.onClick.AddListener(delegate { SaveGame(); });
            _mainMenu.onClick.AddListener(delegate { LoadScene(SceneExample.MainMenu); });
            _exit.onClick.AddListener(delegate { LoadScene(SceneExample.Exit); });
        }

        private void OnDisable()
        {
            _resume.onClick.RemoveListener(delegate { ResumeGame(); });
            _saveGame.onClick.RemoveListener(delegate { SaveGame(); });
            _mainMenu.onClick.RemoveListener(delegate { LoadScene(SceneExample.MainMenu); });
            _exit.onClick.RemoveListener(delegate { LoadScene(SceneExample.Exit); });
        }

        private void ResumeGame()
        {
            Time.timeScale = 1f;
            _pauseMenu.gameObject.SetActive(false);
        }

        private void SaveGame()
        {
            print("Сохраняем игру");
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyUp(KeyCode.Escape))//todo переделать на new input
            {
                Time.timeScale = 0f;
                _pauseMenu.gameObject.SetActive(true);
            }
        }
    }
}