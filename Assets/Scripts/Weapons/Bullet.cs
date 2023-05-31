using UnityEngine;
using TDShooter.Configs;

namespace TDShooter.Weapons
{
    public class Bullet : MonoBehaviour, IDataSOLoader
    {
        [SerializeField] private PojectileData_SO _projectileData_SO;
        private float _speed;
        private int _damage;

        [SerializeField]
        private PojectileData_SO ProjectileData_SO  => _projectileData_SO;
        public float Speed => _speed;
        public int Damage => _damage;
        private void Awake()
        {
            LoadData();
        }

        public void LoadData()
        {
            _speed = _projectileData_SO.Speed;
            _damage = _projectileData_SO.Damage;
        }

        private void Update() => Accelerate();//снаряд может лететь вперёд
        private void Accelerate() => transform.Translate(Speed * Time.deltaTime * Vector3.forward);

    }
}