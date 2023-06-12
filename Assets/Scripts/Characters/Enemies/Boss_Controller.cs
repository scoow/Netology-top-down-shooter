using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TDShooter.Input;
using TDShooter.Level;
using UnityEngine;
using UnityEngine.AI;

public class Boss_Controller : MonoBehaviour
{
    [SerializeField] private Portal _portal;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private PlayerControl _playerControl;

    private float timeOut = 1f;

    private bool isMoving;


    private void OnEnable()
    {
        _portal.TeleportHero += Moving;
    }

    private void OnDisable()
    {
        _portal.TeleportHero -= Moving;
    }

    public void Update()
    {
        if (!isMoving) return;
        timeOut -= Time.deltaTime;
        if (timeOut >= 0f) return;
        _agent.SetDestination(_playerControl.transform.position);        
    }   
    private void Moving()
    {        
        isMoving = true;
    }
}
