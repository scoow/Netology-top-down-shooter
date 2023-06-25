using System.Collections.Generic;
using TDShooter.Characters;
using TDShooter.Configs;
using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.Weapons;
using UnityEngine;
using Zenject;

namespace TDShooter.Talents
{
    public class DroneAssist : MonoBehaviour, IEventListener
    {
        [SerializeField] Player_Data _playerData;
        [Inject]
        private readonly SpawnAssistant _spawnAssistant;
        public Transform _target;
        private Weapon _weapon;
        [SerializeField] private float _shootCoolDown;
        [SerializeField] private float _maxAttackDistance;
        private float _timer;
        public bool _targetFound = false;

        //private Transform parent;
        private void OnEnable()
        {
            //transform.position = _playerData.transform.position - new Vector3(2, -1.424f, 0);
            transform.position = _playerData.transform.position - new Vector3(0, -4f, 0);
            _weapon = GetComponentInChildren<Weapon>();
            _timer = _shootCoolDown;
        }
        private void Start()
        {
            DisableDrone();
        }
        public void EnableDrone()
        {
            gameObject.SetActive(true);
        }
        private float Distance(Transform target)
        {
            return Vector3.Distance(transform.position, target.position);
        }
        public void DisableDrone()
        {
            gameObject.SetActive(false);
        }
        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer < 0)
            {
                if (_targetFound)
                {
                    RotateAndShoot();
                }
                else
                {
                    _timer = _shootCoolDown;
                    SetNewTarget();
                }
            }

        }
        private void SetNewTarget()
        {
            List<BaseEnemy> enemies = _spawnAssistant.FindAllEnemies();
            //BaseEnemy nearestEnemy = enemies.OrderBy(x => Distance(x.transform)).FirstOrDefault(x => Distance(x.transform) < _maxAttackDistance);
            if (enemies.Count > 0)
            {
                float minDistance = Distance(enemies[0].transform);
                BaseEnemy nearestEnemy = null;
                foreach (BaseEnemy enemy in enemies)
                {
                    if (Distance(enemy.transform) < minDistance)
                    {
                        minDistance = Distance(enemy.transform);
                        nearestEnemy = enemy;
                    }

                }

                if (nearestEnemy != null && Distance(nearestEnemy.transform) < _maxAttackDistance)
                {
                    _target = nearestEnemy.transform;
                    _targetFound = true;
                }
            }
        }

        private void RotateAndShoot()
        {
            //Quaternion sight = Quaternion.LookRotation(_target.position - transform.position, Vector3.up);
            //parent.transform.LookAt(_target);
            
            /*            sight.x = 0;
                        sight.z = 0;
                        transform.rotation = sight;*/
            if (_targetFound)
            {
                transform.LookAt(_target);
                _weapon.Shoot();
            }

        }

        public void OnEvent(GameEventType eventType, Component sender, Object param = null)
        {
            ResetTargetAsync();
        }

        private void ResetTargetAsync()
        {
            _targetFound = false;
            _target = null;
            _weapon.CancelShoot();
            //await UniTask.Delay(2000);
        }
    }
}