using System.Collections.Generic;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.EventManager
{
    public class SubscribeManager : MonoBehaviour
    {
        /// <summary>
        /// ключ - тип события, значение - список подписанных
        /// </summary>
        private readonly Dictionary<GameEventType, List<IEventListener>> Listeners = new();
        /// <summary>
        /// Добавление подписчика на событие
        /// </summary>
        /// <param name="eventType">тип события</param>
        /// <param name="listener">подписчик</param>
        public void AddListener(GameEventType eventType, IEventListener listener)
        {
            List<IEventListener> listenList = null;
            if (Listeners.TryGetValue(eventType, out listenList))
            {
                //если список существует, добавить новый элемент
                listenList.Add(listener);
                return;
            }

            listenList = new List<IEventListener>
            {
                listener
            };
            Listeners.Add(eventType, listenList);
        }
        /// <summary>
        /// Удалить одного подписчика
        /// </summary>
        /// <param name="eventType">тип события</param>
        /// <param name="listener">удаляемый подписчик</param>
        public void RemoveListener(GameEventType eventType, IEventListener listener)
        {
            Listeners[eventType]?.Remove(listener);
        }
        /// <summary>
        /// Удалить событие вместе со всеми подписчиками
        /// </summary>
        /// <param name="eventType">тип события</param>
        public void RemoveEvent(GameEventType eventType)
        {
            List<IEventListener> listenList = null;
            if (Listeners.TryGetValue(eventType, out listenList))
            {
                foreach (IEventListener listener in listenList)
                {
                    RemoveListener(eventType, listener);
                }
            }
            Listeners.Remove(eventType);
        }
        /// <summary>
        /// Оповестить всех подписчиков на событие
        /// </summary>
        /// <param name="eventType">тип события</param>
        /// <param name="sender">источник события</param>
        /// <param name="param">дополнительный параметр</param>
        public void PostNotification(GameEventType eventType, Component sender, Object param = null)
        {
            List<IEventListener> listenList = null;
            //если нет такого события в словаре
            if (!Listeners.TryGetValue(eventType, out listenList))
                return;
            //событие есть
            foreach (IEventListener listener in listenList)
            {
                listener.OnEvent(eventType, sender, param);
            }

        }
    }
}