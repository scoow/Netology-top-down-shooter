using TDShooter.Input;
using TDShooter.Level;
using UnityEngine;
using UnityEngine.AI;


public class Boss_Controller : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Portal _portal;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private PlayerControl _playerControl;

    //private float timeOut = 1f;
    private int _attackAnimation;
    private int _moveAnimation;
    private int _deathAnimation;

    private bool isMoving;
    public bool finishAtack = true;
    public bool atack = false;


    private void OnEnable()
    {
        _portal.TeleportHero += Moving;
    }

    private void OnDisable()
    {
        _portal.TeleportHero -= Moving;
    }

    private void Start()
    {
        _attackAnimation = Animator.StringToHash("Atack");
        _moveAnimation = Animator.StringToHash("Move");
        _deathAnimation = Animator.StringToHash("Death");
    }

    public void Update()
    {
        if (!isMoving) return;
        //timeOut -= Time.deltaTime;
        //if (timeOut >= 0f) return;        
        float distance = Vector3.Distance(transform.position, _playerControl.transform.position);
        if (distance <= _agent.stoppingDistance )
        {            //finishAtack = false;
            _animator.SetTrigger(_attackAnimation);
        }
        if (distance > _agent.stoppingDistance && finishAtack)
        {
            _agent.SetDestination(_playerControl.transform.position);
            _animator.SetTrigger(_moveAnimation);
        }               
    }   
    private void Moving()
    {        
        isMoving = true;
    }

    //public void FinishAtack()
    //{
    //    finishAtack = true;
    //}
}
