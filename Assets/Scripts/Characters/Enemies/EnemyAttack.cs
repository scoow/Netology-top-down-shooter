using TDShooter.Input;
using UnityEngine;

namespace TDShooter.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        /// <summary>
        /// Цель атаки
        /// </summary>
        private Transform _target;
        [SerializeField] Animator _animator;

        /// <summary>
        /// Дальность атаки
        /// </summary>
        [SerializeField]
        private float _attackRange = 2;
        [SerializeField]
        private float _attackCooldown = 4;//кд до атаки
        private float _timer;//время для отсчёта кд
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
            CalculateAttackCoolDownTime();
        }

        private void CalculateAttackCoolDownTime()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _timer = _attackCooldown;

                if (TargetInAttackRange(_target))
                {
                    Attack();
                }
                else
                {
                    StopAtack();
                }
            }
        }

        private void Attack()
        {
            Debug.Log("Атакую!");
            _animator.SetBool("Atack", true);
        }

        private void StopAtack()
        {
            _animator.SetBool("Atack", false);
        }
    }
}