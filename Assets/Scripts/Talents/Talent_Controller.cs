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
        private readonly PlayerProgress _playerProgress;

        public void EnableTalent(TalentType? talentOne, TalentType? talentTwo) //активируем панель талантов
        {
            if (talentOne != null)
            {
                Talents_Base oneAccessibleTalant = ChoiseTalent(talentOne);
                _talentOneView.EnableTalantView(oneAccessibleTalant);
            }
            if (talentTwo != null)
            {
                Talents_Base twoAccessibleTalant = ChoiseTalent(talentTwo);
                _talentTwoView.EnableTalantView(twoAccessibleTalant);
            }
        }

        private Talents_Base ChoiseTalent(TalentType? talentExample) //выбор таланта
        {
            Talents_Base result = talentExample switch
            {
                TalentType.StoneSkin => new StoneSkin_Talent(_playerData),
                TalentType.Radar => new Radar_Talent(_playerData),
                TalentType.ExtraFireRate => new ExtraFireRate_Talent(_playerData),
                TalentType.ExtraWeaponDamage => new ExtraWeaponDamage_Talent(_playerData),
                TalentType.Drone => new Drone_Talent(_playerData),
                TalentType.NuclearCharge => new NuclearCharge_Talent(_playerData, _playerProgress),
                _ => null,
            };
            return result;

/*            if (talentExample == TalentType.StoneSkin) return new StoneSkin_Talent(_playerData);
            else if (talentExample == TalentType.Radar) return new Radar_Talent(_playerData);
            else if (talentExample == TalentType.ExtraFireRate) return new ExtraFireRate_Talent(_playerData);
            else if (talentExample == TalentType.ExtraWeaponDamage) return new ExtraWeaponDamage_Talent(_playerData);
            else if (talentExample == TalentType.Drone) return new Drone_Talent(_playerData);
            else if (talentExample == TalentType.NuclearCharge) return new NuclearCharge_Talent(_playerData, _playerProgress);
            else return null;*/
        }
        private void OnDestroy()
        {
            
        }
    }
}