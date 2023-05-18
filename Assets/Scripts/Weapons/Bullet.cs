using UnityEngine;

namespace TDShooter.Weapons
{
    public class Bullet : MonoBehaviour//todo переименовать в projectile
    {
        [SerializeField] private float _speed;
        private void Update() => Accelerate();//снаряд может лететь вперёд
        private void Accelerate() => transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }
}