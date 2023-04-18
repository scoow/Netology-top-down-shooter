using UnityEngine;

namespace TDShooter.Weapons//перенести в глобальный namespace, использовать повторно для аптечек
{
    public class LifeTimer : MonoBehaviour
    {
        [SerializeField]
        private float _lifeTime;

        private void Update()
        {
            _lifeTime -= Time.deltaTime;
            if (_lifeTime < 0)
                Destroy(gameObject);
        }
    }
}