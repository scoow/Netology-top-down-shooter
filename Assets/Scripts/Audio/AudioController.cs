using TDShooter.enums;
using TDShooter.EventManager;
using UnityEngine;

namespace TDShooter.Audio
{
    public class AudioController : MonoBehaviour, IEventListener
    {
        [SerializeField]
        private AudioSource _audioSourceSteps;
        [SerializeField]
        private AudioClip _oneShotSound;
        [SerializeField]
        private AudioClip _oneStepSound;

        public void OnEvent(GameEventType eventType, Component sender, Object param = null)
        {
            switch (eventType)
            {
                case GameEventType.PlayShootSound:
                    _audioSourceSteps.PlayOneShot(_oneShotSound);
                    break;
                case GameEventType.PlayStepSound:
                    _audioSourceSteps.PlayOneShot(_oneStepSound);
                    break;
            }
        }
    }
}