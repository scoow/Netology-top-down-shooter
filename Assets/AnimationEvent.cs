using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    [SerializeField] Boss_Move _boss_Move;

/*    public void FinishAtack() /// сделанно криво , событие анимации может вызвать определенный метод на том же игровом объекте
    {
        _boss_Move.finishAtack = true;
    }

    public void Atack()
    {
        _boss_Move.finishAtack = false;
    }*/
}