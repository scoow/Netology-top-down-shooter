using TDShooter.Characters;
using UnityEngine;

namespace TDShooter.Weapons
{
    public class OnHit : MonoBehaviour
    {
        [SerializeField] private Bullet bullet;
        /// <summary>
        /// ������ ����� � ����
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<IDamageble>(out var target)) return;
            //if (other.TryGetComponent<PlayerControl>(out _)  == true) return;//���� ���� ����� � ������
            target.TakeDamage(bullet.Damage);

            gameObject.SetActive(false);
        }
    }
}
