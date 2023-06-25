using TDShooter.Characters;
using TDShooter.Configs;
using TDShooter.EventManager;
using TDShooter.Input;
using UnityEngine;

namespace TDShooter.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] protected Enemy_Data _enemy_Data;
        
        protected Animation_Controller _animation_Controller;
        /// <summary>
        /// Цель атаки
        /// </summary>
        protected Transform _target;
        protected Character _player;

        protected SubscribeManager _subscribeManager;

        /// <summary>
        /// Дальность атаки
        /// </summary>
        [SerializeField]
        private float _attackRange = 2;

        public float AttackRange => _attackRange;

        protected virtual void Awake()
        {
            _animation_Controller = GetComponent<Animation_Controller>();
            _target = FindObjectOfType<PlayerControl>().transform;
            _player = _target.GetComponent<Character>();
            _subscribeManager = FindObjectOfType<SubscribeManager>();
        }
        /// <summary>
        /// Проверка, достаём ли до цели
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool TargetInAttackRange(Transform target)
        {
            return Distance(target.transform) < _attackRange;
        }
        private float Distance(Transform target)
        {
            return Vector3.Distance(transform.position, target.position);
        }
        protected virtual void Update()
        {            
            _animation_Controller?.ChangeAnimation(_target);
        }

        public void Attack()
        {
            if (Distance(_target) < _attackRange)
            {
                _player.TakeDamage(_enemy_Data.Damage);
                Debug.Log("Атакую!");
                _subscribeManager.PostNotification(enums.GameEventType.EnemyAttacked, this);
            }
        }
    }
}