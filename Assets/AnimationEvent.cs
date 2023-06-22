using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    [SerializeField] Boss_Controller _boss_Controller;



    public void FinishAtack() /// сделанно криво , событие анимации может вызвать определенный метод на том же игровом объекте
    {
        _boss_Controller.finishAtack = true;
    }

    public void Atack()
    {
        _boss_Controller.finishAtack = false;
    }
}