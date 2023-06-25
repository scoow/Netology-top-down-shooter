using TDShooter.Enemies;
using TDShooter.enums;
using TDShooter.EventManager;
using UnityEngine;


public class Boss_Controller : MonoBehaviour, IEventListener
{
    private Boss_Move _bossMove;   

    private void OnEnable()
    {
       _bossMove = FindObjectOfType<Boss_Move>();//переделать
        _bossMove.gameObject.SetActive(false);
    }
    
    private void ActivateBoss()
    {
        _bossMove.gameObject.SetActive(true);
    }

    public void OnEvent(GameEventType eventType, Component sender, Object param = null)
    {
        ActivateBoss();
    }
}
