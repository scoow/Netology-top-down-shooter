using TDShooter.Configs;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.Talents
{
    public abstract class Talents_Base
    {
        private Player_Data player_Data;
        private Sprite _talentSprite;
        private string _description;
        protected bool _activated = false;

        public Sprite TalentSprite { get => _talentSprite; protected set => _talentSprite = value; }
        public string Description { get => _description; protected set => _description = value; }
        protected Player_Data Player_Data { get => player_Data; private set => player_Data = value; }

        public Talents_Base(Player_Data player_Data)
        {
            Player_Data = player_Data;
        }

        public virtual void ActivateTalant() { }
        public virtual TalentType GetTalantType() { return TalentType.Radar; }
    }
}