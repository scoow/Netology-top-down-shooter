using UnityEngine;

namespace TDShooter.Weapons
{
    public class Bullet : MonoBehaviour//todo ������������� � projectile
    {
        [SerializeField] private float _speed;
        private void Update() => Accelerate();//������ ����� ������ �����
        private void Accelerate() => transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }
}