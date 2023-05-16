using TDShooter.Characters;
using UnityEngine;

namespace TDShooter.Weapons
{
    public class OnHit : MonoBehaviour
    {
        /// <summary>
        /// Снаряд попал в цель
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<IHaveHP>(out var target)) return;

            //Debug.Log("Снаряд попал в цель");
            target.TakeDamage(1);

            gameObject.SetActive(false);
        }
    }
}
