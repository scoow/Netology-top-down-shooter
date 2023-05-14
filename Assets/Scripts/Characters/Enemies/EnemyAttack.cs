using TDShooter.Input;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace TDShooter.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] Animation_Controller _animation_Controller;
        /// <summary>
        /// Цель атаки
        /// </summary>
        private Transform _target;         

        /// <summary>
        /// Дальность атаки
        /// </summary>
        [SerializeField]
        private float _attackRange = 2;
        [SerializeField]
        private float _attackCooldown = 4;//кд до атаки
        private float _timer;//время для отсчёта кд

        public float AttackRange => _attackRange;


        private void Awake()
        {
            _target = FindObjectOfType<PlayerControl>().transform;
        }
        private void OnEnable()
        {
            _timer = _attackCooldown;
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
        private void Update()
        {            
            _animation_Controller.ChangeAnimation(_target);
            //CalculateAttackCoolDownTime();
        }

        private void CalculateAttackCoolDownTime()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _timer = _attackCooldown;

                if (TargetInAttackRange(_target))
                {
                    _animation_Controller.ChangeAnimation(_target);
                }                
            }
        }
        /*private void Attack()
        {
            Debug.Log("Атакую!");
            _animator.SetBool("Atack", true);
        }

        private void StopAtack()
        {
            _animator.SetBool("Atack", false);
        }*/
    }
}