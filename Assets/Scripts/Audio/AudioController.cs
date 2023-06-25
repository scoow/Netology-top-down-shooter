using TDShooter.Characters;
using TDShooter.enums;
using TDShooter.EventManager;
using Unity.VisualScripting;
using UnityEngine;

namespace TDShooter.Audio
{
    public class AudioController : MonoBehaviour, IEventListener
    {
        [SerializeField]
        private AudioSource _backGroundMusic;
        [SerializeField]
        private AudioSource _audioSourceSteps;
        [SerializeField]
        private AudioClip _oneShotSound;
        [SerializeField]
        private AudioClip _oneStepSound;
        [SerializeField]
        private AudioClip _spiderSpawn;
        [SerializeField]
        private AudioClip _spiderAttack;
        [SerializeField]
        private AudioClip _spiderDeath;
        [SerializeField]
        private AudioClip _monsterSpawn;
        [SerializeField]
        private AudioClip _monsterAttack;
        [SerializeField]
        private AudioClip _monsterDeath;
        [SerializeField]
        private AudioClip _bigBossLevel;

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
                case GameEventType.EnemySpawned:
                    PlayEnemySpawnedSound(sender);
                    break;
                case GameEventType.EnemyAttacked:
                    PlayEnemyAttackedSound(sender);
                    break;
                case GameEventType.EnemyDied:
                    PlayEnemyDiedSound(sender);
                    break;
                case GameEventType.PortalActivated:
                    _backGroundMusic.clip = _bigBossLevel;
                    _backGroundMusic.Play();
                    break;
            }
    }

        private void PlayEnemyDiedSound(Component sender)
        {
            var enemy = (BaseEnemy)sender;
            var character = enemy.CharacterType;
            switch (character)
            {
                case ÑharacterType.FastMeleeEnemy:
                    _audioSourceSteps.PlayOneShot(_monsterDeath);
                    break;
                case ÑharacterType.Spider:
                    _audioSourceSteps.PlayOneShot(_spiderDeath);
                    break;
                default:
                    break;
            }
        }

        private void PlayEnemyAttackedSound(Component sender)
        {
            var enemy = sender.GetComponent<BaseEnemy>();
            var character = enemy.CharacterType;
            switch (character)
            {
                case ÑharacterType.FastMeleeEnemy:
                    _audioSourceSteps.PlayOneShot(_monsterAttack);
                    break;
                case ÑharacterType.Spider:
                    _audioSourceSteps.PlayOneShot(_spiderAttack);
                    break;
                default:
                    break;
            }
        }

        private void PlayEnemySpawnedSound(Component sender)
        {
            var enemy = (BaseEnemy)sender;
            var character = enemy.CharacterType;
            switch (character)
            {
                case ÑharacterType.FastMeleeEnemy:
                    _audioSourceSteps.PlayOneShot(_monsterSpawn);
                    break;
                case ÑharacterType.Spider:
                    _audioSourceSteps.PlayOneShot(_spiderSpawn);
                    break;
                default:
                    break;
            }
            }
        }
    }