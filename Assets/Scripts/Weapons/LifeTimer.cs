using UnityEngine;

namespace TDShooter.Weapons
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
    }
}