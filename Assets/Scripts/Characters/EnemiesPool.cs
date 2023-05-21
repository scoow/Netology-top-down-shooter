using System.Collections.Generic;
using System.Linq;
using TDShooter.enums;
using TDShooter.Pools;
using UnityEngine;

namespace TDShooter.Characters
{
    public class EnemiesPool : BasePool<BaseEnemy>
    {
        protected �haracterType _unitType;

        public EnemiesPool(BaseEnemy prefab, �haracterType unitType, Transform parent, int count = 1) : base(prefab, parent)
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
        /// ����������� ������� � ������ �������� ������
        /// </summary>
        /// <returns>������ �������� ������</returns>
        public List<BaseEnemy> GetActiveUnits()
        {
            return _elements.Where(x => x.isActiveAndEnabled).ToList();
        }
    }
}