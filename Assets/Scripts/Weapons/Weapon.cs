using UnityEngine;

namespace TDShooter.Weapons
{
    public class Weapon : MonoBehaviour
    {
        private ShootingPoint _shootingPoint;
        [SerializeField]
        private GameObject _bullet;
        private void Start()
        {
            _shootingPoint = GetComponentInChildren<ShootingPoint>();
        }
        public void Shoot()
        {
            var projectile = Instantiate(_bullet, _shootingPoint.transform.position, _shootingPoint.transform.rotation);
        }
    }
}