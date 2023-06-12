using System.Collections.Generic;
using System.Linq;
using TDShooter.Characters;
using TDShooter.Configs;
using TDShooter.Weapons;
using UnityEngine;
using Zenject;

namespace TDShooter.Talents
{
    public class DroneAssist : MonoBehaviour
    {
        [SerializeField] Player_Data _playerData;
        [Inject]
        private SpawnAssistant _spawnAssistant;
        private Vector3 _target;
        private Weapon _weapon;
        [SerializeField] private float _shootCoolDown;
        private float _timer;
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
            if (_timer < 0)
            {
                _timer = _shootCoolDown;
                SetNewTarget();
            }
        }
        private void SetNewTarget()
        {
            List<BaseEnemy> enemies = _spawnAssistant.FindAllEnemies();
            BaseEnemy nearestEnemy = enemies.OrderBy(x => Distance(x.transform)).FirstOrDefault();
            if (nearestEnemy != null)
            {
                _target = nearestEnemy.transform.position;
                
                //transform.LookAt(_target, Vector3.up);
                Quaternion sight = Quaternion.LookRotation(_target - transform.position, Vector3.up);
                sight.x = 0;
                sight.z = 0;
                transform.rotation = sight;

                _weapon.Shoot();
            }
            
        }
    }
}