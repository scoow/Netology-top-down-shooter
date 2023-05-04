using System.Collections.Generic;
using System.Linq;
using TDShooter.enums;
using TDShooter.Pools;
using TDShooter.WinCondition;
using UnityEngine;
using Zenject;

namespace TDShooter.Characters
{
    public class EnemiesPool : BasePool<BaseEnemy>
    {
        protected EnemyType _unitType;
        private readonly EnemyKilledCounter _enemyKilledCounter;

        public EnemiesPool(BaseEnemy prefab, EnemyType unitType, Transform parent, EnemyKilledCounter enemyKilledCounter, int count = 1) : base(prefab, parent)
        {
            _unitType = unitType;
            _enemyKilledCounter = enemyKilledCounter;
            Init(count);
        }
        protected override BaseEnemy GetCreated()
        {
            BaseEnemy newUnit = GameObject.Instantiate(_prefab);
            var character = newUnit.GetComponent<Character>();
            character.Inject(_enemyKilledCounter);

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