using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TDShooter.Input;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Animator_Controller : MonoBehaviour
{
    private Animator _animator;
    private int _runAnimation;

    public void StepSound()
    {
        Debug.Log("Step");
    }

    private void Start()
    {       
        _animator = GetComponent<Animator>();
        _runAnimation = Animator.StringToHash("Run");
    }

    public void Move(Vector2 incomingValue)
    {
        //_animator.SetBool(_runAnimation, incomingValue.x != 0 || incomingValue.y != 0);
        _animator.SetFloat("Forward", incomingValue.y);
        _animator.SetFloat("Turn", incomingValue.x);
    }
}