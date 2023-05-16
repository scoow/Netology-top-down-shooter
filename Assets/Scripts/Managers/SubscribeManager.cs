using System.Collections.Generic;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.EventManager
{
    public class SubscribeManager : MonoBehaviour
    {
        /// <summary>
        /// ���� - ��� �������, �������� - ������ �����������
        /// </summary>
        private readonly Dictionary<GameEventType, List<IEventListener>> Listeners = new();
        /// <summary>
        /// ���������� ���������� �� �������
        /// </summary>
        /// <param name="eventType">��� �������</param>
        /// <param name="listener">���������</param>
        public void AddListener(GameEventType eventType, IEventListener listener, bool asSingle)
        {
            if (Listeners.TryGetValue(eventType, out List<IEventListener> listenList))
            {
                //���� ������ ����������, �������� ����� �������
                if (!asSingle)
                {
                    listenList.Add(listener);
                }
                else
                {
                    if (!listenList.Contains(listener))
                        listenList.Add(listener);
                }

                return;
            }

            listenList = new List<IEventListener>
            {
                listener
            };
            Listeners.Add(eventType, listenList);
        }
        /// <summary>
        /// ������� ������ ����������
        /// </summary>
        /// <param name="eventType">��� �������</param>
        /// <param name="listener">��������� ���������</param>
        public void RemoveListener(GameEventType eventType, IEventListener listener)
        {
            Listeners[eventType]?.Remove(listener);
        }
        /// <summary>
        /// ������� ������� ������ �� ����� ������������
        /// </summary>
        /// <param name="eventType">��� �������</param>
        public void RemoveEvent(GameEventType eventType)
        {
            if (Listeners.TryGetValue(eventType, out List<IEventListener> listenList))
            {
                foreach (IEventListener listener in listenList)
                {
                    RemoveListener(eventType, listener);
                }
            }
            Listeners.Remove(eventType);
        }
        /// <summary>
        /// ���������� ���� ����������� �� �������
        /// </summary>
        /// <param name="eventType">��� �������</param>
        /// <param name="sender">�������� �������</param>
        /// <param name="param">�������������� ��������</param>
        public void PostNotification(GameEventType eventType, Component sender, Object param = null)
        {
            //���� ��� ������ ������� � �������
            if (!Listeners.TryGetValue(eventType, out List<IEventListener> listenList))
                return;
            //������� ����
            foreach (IEventListener listener in listenList)
            {
                listener.OnEvent(eventType, sender, param);
            }

        }
    }
}