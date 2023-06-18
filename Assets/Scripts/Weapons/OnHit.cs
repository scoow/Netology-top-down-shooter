using TDShooter.Characters;
using TDShooter.Input;
using UnityEngine;

namespace TDShooter.Weapons
{
    public class OnHit : MonoBehaviour
    {
        [SerializeField] private Bullet bullet;
        /// <summary>
        /// Снаряд попал в цель
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<IDamageble>(out var target)) return;
            if (other.TryGetComponent<PlayerControl>(out _)  == true) return;//если дрон попал в игрока
            //Debug.Log("Снаряд попал в цель");
            target.TakeDamage(bullet.Damage);

            gameObject.SetActive(false);
        }
    }
}
