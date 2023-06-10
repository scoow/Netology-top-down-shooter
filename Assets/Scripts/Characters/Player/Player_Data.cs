using TDShooter.Characters;
using TDShooter.UI;
using UnityEngine;

namespace TDShooter.Configs
{
    public class Player_Data : Character_Data
    {
        [SerializeField] private UI_Controller _uI_Controller;
        [SerializeField] private Player_UI _playerUI;
        [SerializeField] private Character_Player _playerCharacter;
        [SerializeField] private DroneAssist droneAssist;
        [SerializeField] private MiniMap miniMap;

        public DroneAssist DroneAssist { get => droneAssist;}
        public MiniMap MiniMap { get => miniMap;}

        protected override void Awake()
        {
            base.Awake();
            SetDifficulty(1);

            _playerUI.SetHP(Hp);
        }       
    }
}