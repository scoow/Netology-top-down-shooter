using TDShooter.Configs;
using TDShooter.enums;
using TDShooter.Managers;
using UnityEngine;

namespace TDShooter.Talents
{
    public class NuclearCharge_Talent : Talents_Base
    {
        private PlayerProgress _playerProgress;
        public NuclearCharge_Talent(Player_Data player_Data, PlayerProgress playerProgress) : base(player_Data)
        {
            _playerProgress = playerProgress;
            Description = "Бомба, убивающая всех врагов на экране";
            TalentSprite = Resources.Load<Sprite>("Sprites/UI/Talents/Абилка_2");
        }
        public override void ActivateTalant()
        {
            _playerProgress.ActivateNuclearCharge();
        }

        public override TalentType GetTalantType() { return TalentType.NuclearCharge; }
    }
}