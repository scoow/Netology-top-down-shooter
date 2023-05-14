using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TDShooter.Input;
using UnityEngine;

public class Animator_Controller : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move(Vector2 incomingValue/*, DirectionState directionMove*/)
    {
        /*if( nameAnimation == "Forward")
        {
            _animator.SetBool("Forward", true);
            _animator.SetBool("Back", false);
        }
        if( nameAnimation == "Back")
        {
            _animator.SetBool("Forward", false);
            _animator.SetBool("Back", true);
        }*/
        /*if(incomingValue.x != 0 || incomingValue.y != 0)
        {
            if(directionMove == DirectionState.Forward)
            {
                _animator.SetBool("Run", true);
                _animator.SetBool("Back", false);               

            }
            if(directionMove == DirectionState.Back)
            {
                _animator.SetBool("Run", false);
                _animator.SetBool("Back", true);
            }
            
        }
        else
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Back", false);
        }
        */

        _animator.SetBool("Run", incomingValue.x != 0 || incomingValue.y != 0);            
    }
}