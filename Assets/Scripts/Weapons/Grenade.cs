using TDShooter.Characters;
using TDShooter.Effects;
using TDShooter.EventManager;
using TDShooter.Input;
using UnityEngine;

namespace TDShooter.Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class Grenade : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _maxThrowDistance;

        [SerializeField] private int _damage;
        [SerializeField] private float _explosionRadius;
        [SerializeField] private ExplosionEffect _explosion;
        private SubscribeManager _subscribeManager;

        private bool _isExplosion;
        private float _timer;
        private void OnEnable()
        {
            ResetGrenadeTimer();
        }

        private void Start()
        {
            _explosion = FindObjectOfType<ExplosionEffect>();
            _subscribeManager = FindObjectOfType<SubscribeManager>();
        }

        private void ResetGrenadeTimer()
        {
            _lifeTime = 0.2f;
            _isExplosion = false;
        }

        public void Throw(Vector3 target)
        {
            _timer = _lifeTime;
            Vector3 fromTo = target - transform.position;
            Vector3 fromToXZ = new(fromTo.x, 0f, fromTo.z);

            transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);

            float x = fromToXZ.magnitude;
            float y = fromTo.y;

            float v = Mathf.Sqrt(Mathf.Abs((Physics.gravity.y * x * x) / (y - x)));

            Vector3 angle = fromTo.normalized + Vector3.up;
            GetComponent<Rigidbody>().velocity = angle.normalized * v;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _isExplosion = true;
            }
        }
        public void Explode()
        {
            _subscribeManager.PostNotification(enums.GameEventType.GrenadeExplosion, this);
            gameObject.SetActive(false);

            Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);
            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent<BaseEnemy>(out BaseEnemy enemy))
                    enemy.TakeDamage(_damage);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isExplosion)
            {
                _explosion.gameObject.transform.position = gameObject.transform.position;
                _explosion.GetComponent<ParticleSystem>().Play();
                Explode();
            }
        }
    }
}