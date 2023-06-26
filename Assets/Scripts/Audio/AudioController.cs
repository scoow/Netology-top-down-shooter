using TDShooter.Characters;
using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.UI;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

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
        [SerializeField]
        private AudioClip _shotgunShoot;
        [SerializeField]
        private AudioClip _plasmaShoot;
        [SerializeField]
        private AudioClip _grenadeExplosion;
        [SerializeField]
        private AudioClip _playerScream;
        [Inject] private WeaponChanger _weaponChanger;

        public void OnEvent(GameEventType eventType, Component sender, Object param = null)
        {
            switch (eventType)
            {
                case GameEventType.PlayShootSound:
                    PlayWeaponShootSound(_weaponChanger.CurrentWeaponType);
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
                case GameEventType.PlayerScream:
                    _audioSourceSteps.PlayOneShot(_playerScream);
                    break;
                case GameEventType.GrenadeExplosion:
                    _audioSourceSteps.PlayOneShot(_grenadeExplosion);
                    break;
                case GameEventType.PortalActivated:
                    _backGroundMusic.Stop();
                    _backGroundMusic.clip = _bigBossLevel;
                    _backGroundMusic.Play();
                    break;
            }
    }

        private void PlayWeaponShootSound(WeaponType weaponType)
        {
            switch (weaponType)
            {
                case WeaponType.Machinegun:
                    _audioSourceSteps.PlayOneShot(_oneShotSound);
                    break;
                case WeaponType.Shothun:
                    _audioSourceSteps.PlayOneShot(_shotgunShoot);
                    break;
                case WeaponType.Plasmagun:
                    _audioSourceSteps.PlayOneShot(_plasmaShoot);
                    break;
                case WeaponType.BFG:
                    _audioSourceSteps.PlayOneShot(_plasmaShoot);
                    break;
                default:
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