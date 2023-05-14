using TDShooter.enums;
using UnityEngine;

namespace TDShooter.EventManager
{
    /// <summary>
    /// ��������� ���������� �������
    /// </summary>
    public interface IEventListener
    {
        void OnEvent(GameEventType eventType, Component sender, Object param = null);
    }
}