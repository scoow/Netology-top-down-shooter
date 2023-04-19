using UnityEngine;

namespace TDShooter.Weapons//перенести в глобальный namespace, использовать повторно для аптечек
{
    public class LifeTimer : MonoBehaviour
    {
        [SerializeField]
        private float _lifeTime;
        private float _lifeTimeLeft;

        private void OnEnable()
        {
            _lifeTimeLeft = _lifeTime;
        }
        private void Update()
        {
            _lifeTimeLeft -= Time.deltaTime;
            if (_lifeTimeLeft < 0)
                gameObject.SetActive(false);
        }
    }
}