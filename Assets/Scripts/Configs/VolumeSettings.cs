using UnityEngine;

namespace TDShooter.Configs
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/VolumeConfig", order = 1)]
    public class VolumeSettings : ScriptableObject
    {
        [SerializeField] private bool _effectsSoundEnabled;
        [SerializeField] private bool _musicSoundEnabled;
        public bool EffectsSoundEnabled { set { _effectsSoundEnabled = value; } get => _effectsSoundEnabled; }
        public bool MusicSoundEnabled { set { _musicSoundEnabled = value; } get => _musicSoundEnabled; }
    }
}