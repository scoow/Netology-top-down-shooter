using UnityEngine;
using TDShooter.Configs;
using TDShooter.enums;

namespace TDShooter.Weapons
{
    public class Bullet : MonoBehaviour//todo переименовать в projectile
    {
        [SerializeField] private PojectileData_SO _projectileData_SO;
        private float _speed;
        private int _damage;

        public PojectileData_SO ProjectileData_SO  => _projectileData_SO;
        public float Speed { get => _speed; set => _speed = value; }
        public int Damage { get => _damage; set => _damage = value; }

        private void Awake()
        {
            Speed = _projectileData_SO.Speed;
            Damage = _projectileData_SO.Damage;           
        }

        private void Update() => Accelerate();//снаряд может лететь вперёд
        private void Accelerate() => transform.Translate(Speed * Time.deltaTime * Vector3.forward);
    }
}