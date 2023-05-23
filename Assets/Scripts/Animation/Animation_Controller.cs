using System.Collections;
using UnityEngine;

namespace TDShooter.Enemies
{
    public class Animation_Controller : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] EnemyAttack _enemyAttack; 
        private EnemyAnimationState _enemyState = EnemyAnimationState.Move;

        private int _atackAnimation;
        private int _runAnimation;
        private int _indexDeathAnimation;

        public EnemyAnimationState EnemyState { get=> _enemyState; set=> _enemyState = value; }

        private void Start()
        {
            _atackAnimation = Animator.StringToHash("Atack");
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
            gameObject.SetActive(false);
        }

        public void ChangeAnimation(Transform target)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance < _enemyAttack.AttackRange && _enemyState == EnemyAnimationState.Move)
            {
                _animator.SetTrigger(_atackAnimation);
                _enemyState = EnemyAnimationState.Atack;
            }
            if (distance > _enemyAttack.AttackRange && _enemyState == EnemyAnimationState.Atack)
            {
                _animator.SetTrigger(_runAnimation);
                _enemyState = EnemyAnimationState.Move;
            }            
        }
    }

    public enum EnemyAnimationState
    {
        Move,
        Atack,
        Death
    }
}