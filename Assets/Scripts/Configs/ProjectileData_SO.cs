using UnityEngine;

namespace TDShooter.Configs
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NewProjectile", order = 1)]
    public class ProjectileData_SO : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;

        public float Speed { get => _speed; set => _speed = value; }
        public int Damage => _damage;
    }
}