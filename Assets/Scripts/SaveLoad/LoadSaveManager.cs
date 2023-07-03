using System.Collections.Generic;
using TDShooter.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDShooter.SaveLoad
{
    /// <summary>
    /// Менеджер загрузки и сохранения
    /// </summary>
    public class LoadSaveManager : MonoBehaviour
    {
        private ISaver _fileSaver;
        private readonly List<ISavable> _savables = new();

        private bool _resetProgress;
        
        public bool ResetProgress { get { return _resetProgress; } set {  _resetProgress = value; } }

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
        private void Start()
        {
            _resetProgress = true;
            
        }
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "StartMenu") return;

            _savables.Add(FindObjectOfType<PlayerProgress>());
            if (!_resetProgress)
            {
                LoadGame();
            }
        }

        private void LoadGame()
        {
            _fileSaver = new FileSaver(_savables);
            _fileSaver.Load();
        }

        public void SaveGame()
        {
            _fileSaver = new FileSaver(_savables);
            _fileSaver.Save();
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}