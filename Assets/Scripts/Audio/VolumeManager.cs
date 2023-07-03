using TDShooter.Configs;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace TDShooter.Audio
{
    public class VolumeManager : MonoBehaviour
    {
        [SerializeField]
        private VolumeSettings _volumeSettings;
        [SerializeField]
        private AudioMixerGroup _musicMixerGroup;
        [SerializeField]
        private AudioMixerGroup _effectsMixerGroup;


        private void Awake()
        {
            UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "StartMenu")
            {
                _volumeSettings.EffectsSoundEnabled = true;
                _volumeSettings.MusicSoundEnabled = true;
            }
                
            UpdateMusic();
            UpdateEffects();
        }
        public void ToggleMusic()
        {
            _volumeSettings.MusicSoundEnabled = !_volumeSettings.MusicSoundEnabled;
            UpdateMusic();
        }
        public void ToggleEffects()
        {
            _volumeSettings.EffectsSoundEnabled = !_volumeSettings.EffectsSoundEnabled;
            UpdateEffects();
        }
        private void UpdateMusic()
        {
            if (_volumeSettings.MusicSoundEnabled)
            {
                _musicMixerGroup.audioMixer.SetFloat("MusicVolume", 0);
            }
            else
            {
                _musicMixerGroup.audioMixer.SetFloat("MusicVolume", -80);
            }
        }
        private void UpdateEffects()
        {
            if (_volumeSettings.EffectsSoundEnabled)
            {
                _effectsMixerGroup.audioMixer.SetFloat("EffectsVolume", 0);
            }
            else
            {
                _effectsMixerGroup.audioMixer.SetFloat("EffectsVolume", -80);
            }
        }
    }
}