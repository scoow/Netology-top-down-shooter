using UnityEngine;

namespace TDShooter.Weapons//перенести в глобальный namespace, использовать повторно для аптечек
{
    public class LifeTimer : MonoBehaviour
    {
        [SerializeField]
        protected float _lifeTime;
        protected float _lifeTimeLeft;

        protected virtual void OnEnable()
        {
            _lifeTimeLeft = _lifeTime;
        }

        protected virtual void Update()
        {
            _lifeTimeLeft -= Time.deltaTime;
            if (_lifeTimeLeft < 0)
                Deactivate();
        }

        protected virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }
/*        protected virtual void DeactivateAsync(float time)
        {
            gameObject.SetActive(false);
        }*/
    }
}