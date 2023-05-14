using System;
using System.Collections;
using System.Collections.Generic;
using TDShooter.Characters;
using UnityEngine;


namespace TDShooter.Enemies
{
    public class Animation_Controller : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] EnemyAttack _enemyAttack; 
        private EnemyAnimationState _enemyState = EnemyAnimationState.Move; 
        
        public EnemyAnimationState EnemyState { get=> _enemyState; set=> _enemyState = value; }


        public void DeathAnimation()
        {
            _animator.SetTrigger("Death");
            _enemyState = EnemyAnimationState.Death;
            StartCoroutine(DeathCoroutine());
            //gameObject.SetActive(false);
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
                _animator.SetTrigger("Atack");
                _enemyState = EnemyAnimationState.Atack;
            }
            if (distance > _enemyAttack.AttackRange && _enemyState == EnemyAnimationState.Atack)
            {
                _animator.SetTrigger("Run");
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