using System.Collections.Generic;
using System.Linq;
using TDShooter.Enemies;
using TDShooter.enums;
using TDShooter.Input;
using TDShooter.Pools;
using UnityEngine;

namespace TDShooter.Characters
{
    public class EnemiesPool : BasePool<BaseEnemy>
    {
        protected СharacterType _unitType;
        private readonly PlayerControl _playerControl;

        public EnemiesPool(BaseEnemy prefab, СharacterType unitType, Transform parent, PlayerControl playerControl, int count = 1) : base(prefab, parent)
        {
            _unitType = unitType;
            _playerControl = playerControl;
            Init(count);
        }
        protected override BaseEnemy GetCreated()
        {
            BaseEnemy newUnit = GameObject.Instantiate(_prefab);
            newUnit.GetComponent<EnemyMove>().InjectPlayerControlReference(_playerControl);
            return newUnit;
        }

        /// <summary>
        /// Конвертация словаря в список активных юнитов
        /// </summary>
        /// <returns>список активных юнитов</returns>
        public List<BaseEnemy> GetActiveUnits()
        {
            return _elements.Where(x => x.isActiveAndEnabled).ToList();
        }
    }
}