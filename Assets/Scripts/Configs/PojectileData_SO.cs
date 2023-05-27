using UnityEngine;

namespace TDShooter.Configs
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NewProjectile", order = 1)]
    public class PojectileData_SO : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;

        public float Speed  => _speed; 
        public int Damage => _damage;
    }
}