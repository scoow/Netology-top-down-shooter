
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseUI_Controller : MonoBehaviour
{
    protected void LoadScene(SceneExample sceneExample)
    {        
        if (sceneExample == SceneExample.NewGame)
            SceneManager.LoadScene(1);
        if (sceneExample == SceneExample.MainMenu)
            SceneManager.LoadScene(0);
        if (sceneExample == SceneExample.Exit)
        {
            Application.Quit();
            Debug.Log("Выход из приложения");
        }
    }
}

public enum SceneExample
{
    NewGame,
    MainMenu,
    Exit,
}
