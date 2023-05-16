using UnityEngine;
using UnityEngine.UI;

public class StartMenu_Controller : BaseUI_Controller
{
    [SerializeField] private Button _newGame;
    [SerializeField] private Button _loadGame;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _exit;


    private void OnEnable()
    {
        _newGame.onClick.AddListener(delegate { LoadScene(SceneExample.NewGame); });
        _loadGame.onClick.AddListener(delegate { LoadNewGame(); });
        _settings.onClick.AddListener(delegate { LoadSettings(); });
        _exit.onClick.AddListener(delegate { LoadScene(SceneExample.Exit); });
    }
    private void OnDisable()
    {
        _newGame.onClick.RemoveListener(delegate { LoadScene(SceneExample.NewGame); });
        _loadGame.onClick.RemoveListener(delegate { LoadNewGame(); });
        _settings.onClick.RemoveListener(delegate { LoadSettings(); });
        _exit.onClick.RemoveListener(delegate { LoadScene(SceneExample.Exit); });
    }

    private void LoadSettings() //заглушка
    {
        print("Загружаем сцену настроек");
    }

    private void LoadNewGame() //заглушка
    {
        print("Загружаем игру");
    }
   
}