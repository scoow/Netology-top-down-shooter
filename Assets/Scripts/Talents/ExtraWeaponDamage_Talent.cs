using TDShooter.Configs;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.Talents
{
    public class ExtraWeaponDamage_Talent : Talents_Base
    {
        ProjectileData_SO _projectileMashineGun_SO;
        ProjectileData_SO _projectilePlasma_SO;
        public ExtraWeaponDamage_Talent(Player_Data player_Data) : base(player_Data)
        {
            Description = "����������� ����������������";
            TalentSprite = Resources.Load<Sprite>("Sprites/UI/Talents/������_4");

            _projectileMashineGun_SO = Resources.Load<ProjectileData_SO>("Projectile_MashineGun");
            _projectilePlasma_SO = Resources.Load<ProjectileData_SO>("Projectile_Plasma");
        }
        public override void ActivateTalant()
        {
            _projectileMashineGun_SO.Speed *= 2;
            _projectilePlasma_SO.Speed *= 2;
            _activated = true;
        }

        //� ������ ������������� �������, ����� ����� ���� ������� ������ �������� ���������� ������, ������� ���������� �������� �� �����
        ~ExtraWeaponDamage_Talent()
        {
            if (_activated) 
            {
                _projectileMashineGun_SO.Speed /= 2;
                _projectilePlasma_SO.Speed /= 2;
            }
        }

        public override TalentType GetTalantType() { return TalentType.ExtraWeaponDamage; }
    }
}