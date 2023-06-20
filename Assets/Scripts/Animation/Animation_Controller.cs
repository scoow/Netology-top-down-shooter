using System.Collections;
using TDShooter.Characters;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.Enemies
{
    public class Animation_Controller : MonoBehaviour
    {
        private Animator _animator;
        private EnemyAttack _enemyAttack;
        private BaseEnemy _parentGameObject;
        private EnemyAnimationState _enemyState = EnemyAnimationState.Move;

        private int _attackAnimation;
        private int _runAnimation;
        private int _indexDeathAnimation;

        public EnemyAnimationState EnemyState => _enemyState;
        public void SetEnemyAnimationState(EnemyAnimationState newEnemyState)
        {
            _enemyState = newEnemyState;
        }
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _enemyAttack = GetComponent<EnemyAttack>();
            _parentGameObject = GetComponentInParent<BaseEnemy>();
        }
        private void Start()
        {
            _attackAnimation = Animator.StringToHash("Atack");
            _runAnimation = Animator.StringToHash("Run");
            _indexDeathAnimation = Animator.StringToHash("IndexDeath");
        }

        public void DeathAnimation()
        {
            int indexAnimation = UnityEngine.Random.Range(1, 4);
            _animator.SetInteger(_indexDeathAnimation, indexAnimation);
            _enemyState = EnemyAnimationState.Death;
            StartCoroutine(DeathCoroutine());            
        }

        private IEnumerator DeathCoroutine()
        {
            yield return new WaitForSeconds(2f);
            _parentGameObject.gameObject.SetActive(false);
        }

        public void ChangeAnimation(Transform target)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance < _enemyAttack.AttackRange && _enemyState == EnemyAnimationState.Move)
            {
                _animator.SetTrigger(_attackAnimation);
                _enemyState = EnemyAnimationState.Attack;
            }
            if (distance > _enemyAttack.AttackRange && _enemyState == EnemyAnimationState.Attack)
            {
                _animator.SetTrigger(_runAnimation);
                _enemyState = EnemyAnimationState.Move;
            }            
        }
    }
}