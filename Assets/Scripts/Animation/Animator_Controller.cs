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

    private void Start()
    {       
        _animator = GetComponent<Animator>();
        _runAnimation = Animator.StringToHash("Run");
    }

    public void Move(Vector2 incomingValue)
    {
        _animator.SetBool(_runAnimation, incomingValue.x != 0 || incomingValue.y != 0);            
    }
}