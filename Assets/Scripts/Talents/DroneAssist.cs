using System.Collections.Generic;
using System.Linq;
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
        private bool _targetFound = false;
        private void OnEnable()
        {
            transform.position = _playerData.transform.position - new Vector3(2, -1.424f, 0);
            _weapon = GetComponentInChildren<Weapon>();
            _timer = _shootCoolDown;
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
            
            if (_targetFound)
            {
                RotateAndShoot();
            }
            else
            {
                if (_timer < 0)
                {
                    _timer = _shootCoolDown;
                    SetNewTarget();
                }
            }
            
        }
        private void SetNewTarget()
        {
            List<BaseEnemy> enemies = _spawnAssistant.FindAllEnemies();
            BaseEnemy nearestEnemy = enemies.OrderBy(x => Distance(x.transform)).FirstOrDefault();
            if (nearestEnemy != null && Distance(nearestEnemy.transform) < _maxAttackDistance)
            {
                _target = nearestEnemy.transform;
                _targetFound = true;

                /**/
               
            }

        }

        private void RotateAndShoot()
        {
            //Quaternion sight = Quaternion.LookRotation(_target.position - transform.position, Vector3.up);
            transform.LookAt(_target);
/*            sight.x = 0;
            sight.z = 0;
            transform.rotation = sight;*/

            _weapon.Shoot();
        }

        public void OnEvent(GameEventType eventType, Component sender, Object param = null)
        {
            _targetFound = false;
            SetNewTarget();
        }
    }
}