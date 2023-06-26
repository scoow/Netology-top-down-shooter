using DG.Tweening;
using TDShooter.enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDShooter.UI
{
    public abstract class BaseUI_Controller : MonoBehaviour
    {
        protected void LoadScene(SceneExample sceneExample)
        {
            DOTween.KillAll();
            Time.timeScale = 1.0f;
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
}