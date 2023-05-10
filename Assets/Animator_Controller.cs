using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Controller : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move(Vector2 incomingValue)
    {
        _animator.SetBool("Run", incomingValue.x != 0 || incomingValue.y != 0);
        /*if(incomingValue.y == 0 && incomingValue.x == 0)
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Idle", true);
            //Debug.Log("Я стою");
        }
            
        if(incomingValue.y != 0 || incomingValue.x != 0)
        {
            //print("Я бегу");
            _animator.SetBool("Run", true);
            _animator.SetBool("Idle", false);
        }*/
            
    }
}