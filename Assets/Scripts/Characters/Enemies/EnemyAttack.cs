using TDShooter.Characters;
using TDShooter.Input;
using UnityEngine;

namespace TDShooter.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] Enemy_Data _enemy_Data;
        
        [SerializeField] Animation_Controller _animation_Controller;
        /// <summary>
        /// ���� �����
        /// </summary>
        private Transform _target;
        private Character _player;

        /// <summary>
        /// ��������� �����
        /// </summary>
        [SerializeField]
        private float _attackRange = 2;
        [SerializeField]
        private float _attackCooldown = 4;//�� �� �����
        private float _timer;//����� ��� ������� ��

        public float AttackRange => _attackRange;


        private void Awake()
        {
            _target = FindObjectOfType<PlayerControl>().transform;
            _player = _target.GetComponent<Character>();            
        }
        private void OnEnable()
        {
            _timer = _attackCooldown;
        }
        /// <summary>
        /// ��������, ������ �� �� ����
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


        public void Attack()
        {
            _player.TakeDamage(_enemy_Data.Damage);
            Debug.Log("������!");
            //_animator.SetBool("Atack", true);
        }

        /*private void StopAtack()
        {
            _animator.SetBool("Atack", false);
        }*/
    }
}