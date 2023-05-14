using System;
using TDShooter.WinCondition;
using UnityEngine;
using Zenject;
using TDShooter.Enemies;

namespace TDShooter.Characters
{
    /// <summary>
    /// Персонаж. По задумке - класс-родитель для игрока и врагов
    /// </summary>
    public class Character : MonoBehaviour, IHaveHP
    {
        [SerializeField]
        private int _hp;
        [SerializeField] private LootExample _exampleLoot;
        [SerializeField] private PlayerProgress _playerProgress;
        [SerializeField] private Animation_Controller _animation_Controller;
        [SerializeField] private EnemyMove _enemyMove;
        public int HP => _hp;

        private EnemyKilledCounter _enemyKilledCounter;

        public Action OnUnitDied;


        public void OnEnable()
        {
            _playerProgress = FindAnyObjectByType<PlayerProgress>();
        }

        public void Construct(EnemyKilledCounter enemyKilledCounter)
        {
            _enemyKilledCounter = enemyKilledCounter;
            OnUnitDied += _enemyKilledCounter.Increment;
        }

        public void Respawn(int maxHP)
        {
            _hp = maxHP;
            gameObject.SetActive(true);
        }
        public void Die()
        {            
            if(_playerProgress.CheckChance() < _playerProgress.ChanceDroopLoot)
            {
                LootExample loot = Instantiate(_exampleLoot);
                loot.transform.position = transform.position;
            }
            _playerProgress.CurrentKilledCount++;            
            _animation_Controller.EnemyState = EnemyAnimationState.Death;
            _enemyMove.MaxSpeed = 0f;
            _animation_Controller.DeathAnimation();
            OnUnitDied?.Invoke();
        }

        public void TakeDamage(int damage)
        {
            _hp -= damage;
            //Debug.Log("HP осталось:" + _hp);
            if (_hp <= 0)
                Die();
        }

        public void TakeHeal(int heal)
        {
            _hp += heal;
        }

       private void OnDisable()
        {
            OnUnitDied -= _enemyKilledCounter.Increment;
        }
    }
}