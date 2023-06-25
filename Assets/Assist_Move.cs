using System.Collections;
using System.Collections.Generic;
using TDShooter.Input;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Assist_Move : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private PlayerControl _playerControl;



    public float distance;

    private int _attackAnimation;
    private int _moveAnimation;
    private int _deathAnimation;

    private float _checkDistanceCoolDown = 0.5f;
    public float _checkDistanceTimer;

    private float _attackCoolDown = 3.2f;
    public float _attackTimer;    

    private void Start()
    {
        _attackAnimation = Animator.StringToHash("Atack");
        _moveAnimation = Animator.StringToHash("Move");        
        _deathAnimation = Animator.StringToHash("Death");
        _checkDistanceTimer = _checkDistanceCoolDown;        
    }
    public void Update()
    {
        _checkDistanceTimer -= Time.deltaTime;
        _attackTimer -= Time.deltaTime;
        

        if (_checkDistanceTimer < 0)
        {
            _checkDistanceTimer = _checkDistanceCoolDown;
            if (_attackTimer < 0)
                CheckDistance();
        }
    }

    private void CheckDistance()
    {
        distance = Vector3.Distance(transform.position, _playerControl.transform.position);
        if (distance <= _agent.stoppingDistance)
        {
            _agent.speed = 0f;
            _attackTimer = _attackCoolDown;
            _animator.SetBool(_attackAnimation, true);
            _animator.SetBool(_moveAnimation, false);            
        }
        else
        {
            _agent.speed = 2.5f;
            _agent.SetDestination(_playerControl.transform.position);
            _animator.SetBool(_attackAnimation, false);
            _animator.SetBool(_moveAnimation, true);            
        }
    }
}