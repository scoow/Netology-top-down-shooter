using TDShooter.Configs;
using TDShooter.enums;
using TDShooter.Managers;
using UnityEngine;
using Zenject;

namespace TDShooter.Talents
{
    public class Talent_Controller : MonoBehaviour
    {
        [SerializeField] private Talent_Marker _talentOneView;
        [SerializeField] private Talent_Marker _talentTwoView;
        [SerializeField] private Player_Data _playerData;
        [Inject]
        private PlayerProgress _playerProgress;

        public void EnableTalent(TalentType? talentOne, TalentType? talentTwo) //активируем панель талантов
        {
            if (talentOne != null)
            {
                Talents_Base oneAccessibleTalant = ChoiseTalant(talentOne);
                _talentOneView.EnableTalantView(oneAccessibleTalant);
            }
            if (talentTwo != null)
            {
                Talents_Base twoAccessibleTalant = ChoiseTalant(talentTwo);
                _talentTwoView.EnableTalantView(twoAccessibleTalant);
            }
        }

        private Talents_Base ChoiseTalant(TalentType? talentExample) //выбор таланта
        {
            if (talentExample == TalentType.StoneSkin) return new StoneSkin_Talent(_playerData);
            else if (talentExample == TalentType.Radar) return new Radar_Talent(_playerData);
            else if (talentExample == TalentType.ExtraFireRate) return new ExtraFireRate_Talent(_playerData);
            else if (talentExample == TalentType.ExtraWeaponDamage) return new ExtraWeaponDamage_Talent(_playerData);
            else if (talentExample == TalentType.Drone) return new Drone_Talent(_playerData);
            else if (talentExample == TalentType.NuclearCharge) return new NuclearCharge_Talent(_playerData, _playerProgress);
            else return null;
        }
    }
}