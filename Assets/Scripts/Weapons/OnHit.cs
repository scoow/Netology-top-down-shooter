using TDShooter.Characters;
using UnityEngine;

namespace TDShooter.Weapons
{
    public class OnHit : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<IHaveHP>(out var target)) return;

            Debug.Log("������ ����� � ����");
            target.TakeDamage(1);

            Destroy(gameObject);
        }
    }
}
