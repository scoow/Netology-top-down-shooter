using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.Weapons;
using UnityEngine;

namespace TDShooter.Audio
{
    public class AudioController : MonoBehaviour, IEventListener
    {
        [SerializeField]
        private AudioSource _audioSourceSteps;
        [SerializeField]
        private AudioClip _oneShotSound;
        public void OnEvent(GameEventType eventType, Component sender, Object param = null)
        {
            if (eventType != GameEventType.Playsound) return;

/*            switch (sender.GetType())
            {
                case Weapon:
                    break;
            }*/
        }
    }
}