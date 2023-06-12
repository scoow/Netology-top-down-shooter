using TDShooter.Configs;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.Talents
{
    public class ExtraWeaponDamage_Talent : Talents_Base
    {
        public ExtraWeaponDamage_Talent(Player_Data player_Data) : base(player_Data)
        {
            Description = "Увеличенная скорострельность";
            TalentSprite = Resources.Load<Sprite>("Sprites/UI/Talents/Абилка_4");
        }
        public override void ActivateTalant()
        {
            PojectileData_SO _projectileMashineGun_SO = Resources.Load<PojectileData_SO>("Projectile_MashineGun");
            PojectileData_SO _projectilePlasma_SO = Resources.Load<PojectileData_SO>("Projectile_Plasma");
            _projectileMashineGun_SO.Speed *= 2;//todo баг. бесконечно увеличивает скорость пуль
            _projectilePlasma_SO.Speed *= 2;
        }
        public override TalentType GetTalantType() { return TalentType.ExtraWeaponDamage; }
    }
}