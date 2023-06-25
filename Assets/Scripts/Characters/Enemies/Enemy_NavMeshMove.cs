using System.Collections;
using System.Collections.Generic;
using TDShooter.Input;
using TDShooter.UI;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class Enemy_NavMeshMove : MonoBehaviour
{

    [SerializeField] protected Animator _animator;
    [SerializeField] protected NavMeshAgent _agent;    
    [SerializeField] protected PlayerControl _playerControl;
    //[Inject]
    //protected readonly PlayerControl _playerControl;


    private void Awake()
    {
        _playerControl = FindAnyObjectByType<PlayerControl>();
    }


    public float distance;

    protected int _attackAnimation;
    protected int _moveAnimation;
    protected int _deathAnimation;

    protected float _checkDistanceCoolDown = 0.5f;
    public float _checkDistanceTimer;

    protected float _attackCoolDown = 3.2f;
    public float _attackTimer;

    protected virtual void Start()
    {
        _attackAnimation = Animator.StringToHash("Atack");
        _moveAnimation = Animator.StringToHash("Move");
        _deathAnimation = Animator.StringToHash("Death");
        _checkDistanceTimer = _checkDistanceCoolDown;
    }
    protected virtual void Update()
    {
        _checkDistanceTimer -= Time.deltaTime;
        _attackTimer -= Time.deltaTime;

        TryCheckDistance();        
    }

    protected virtual void TryCheckDistance()
    {
        if (_checkDistanceTimer < 0)
        {
            CheckDistance();
        }
    }

    protected virtual void CheckDistance()
    {
        _checkDistanceTimer = _checkDistanceCoolDown;
        if (_attackTimer >= 0) return;

        distance = Vector3.Distance(transform.position, _playerControl.transform.position);

        if (distance <= _agent.stoppingDistance)
        {
            AnimationAtack();
        }
        else
        {
            AnimationMove();
        }
    }

    protected virtual void AnimationMove()
    {
        _agent.speed = 2.5f;
        _agent.SetDestination(_playerControl.transform.position);
        _animator.SetBool(_attackAnimation, false);
        _animator.SetBool(_moveAnimation, true);
    }

    protected virtual void AnimationAtack()
    {
        _agent.speed = 0f;
        _attackTimer = _attackCoolDown;
        _animator.SetBool(_attackAnimation, true);
        _animator.SetBool(_moveAnimation, false);
    }
}