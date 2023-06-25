using System.Collections.Generic;
using System.Linq;
using TDShooter.Enemies;
using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.Input;
using TDShooter.Pools;
using UnityEngine;

namespace TDShooter.Characters
{
    public class EnemiesPool : BasePool<BaseEnemy>
    {
        protected СharacterType _unitType;
        private readonly PlayerControl _playerControl;
        private readonly SubscribeManager _subscribeManager;

        public EnemiesPool(BaseEnemy prefab, СharacterType unitType, Transform parent, PlayerControl playerControl, SubscribeManager subscribeManager, int count = 1) : base(prefab, parent)
        {
            _unitType = unitType;
            _playerControl = playerControl;
            _subscribeManager = subscribeManager;
            Init(count);
        }
        protected override BaseEnemy GetCreated()
        {
            BaseEnemy newUnit = GameObject.Instantiate(_prefab);

            newUnit.InjectReferences(_playerControl, _subscribeManager);

            newUnit.GetComponent<EnemyMove>()?.InjectPlayerControlReference(_playerControl);
            return newUnit;
        }

        /// <summary>
        /// Конвертация словаря в список активных юнитов
        /// </summary>
        /// <returns>список активных юнитов</returns>
        public List<BaseEnemy> GetActiveUnits()
        {
            return _elements.Where(x => x.isActiveAndEnabled && x.EnemyAnimationState == EnemyAnimationState.Move).ToList();
        }
    }
}