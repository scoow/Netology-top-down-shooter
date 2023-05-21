using System.Collections.Generic;
using System.Linq;
using TDShooter.enums;
using TDShooter.Pools;
using UnityEngine;

namespace TDShooter.Characters
{
    public class EnemiesPool : BasePool<BaseEnemy>
    {
        protected СharacterType _unitType;

        public EnemiesPool(BaseEnemy prefab, СharacterType unitType, Transform parent, int count = 1) : base(prefab, parent)
        {
            _unitType = unitType;
            Init(count);
        }
        protected override BaseEnemy GetCreated()
        {
            BaseEnemy newUnit = GameObject.Instantiate(_prefab);
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