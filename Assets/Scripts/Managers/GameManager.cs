using UnityEngine;
using Zenject;

namespace TDShooter.Managers.GameManager
{
    public class GameManager : MonoInstaller
    {
        //Простая реализация - синглтон. В дальнейшем планирую добавить DI
        public static GameManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }
    }
}