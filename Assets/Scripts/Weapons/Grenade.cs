using System.Linq;
using TDShooter.Characters;
using TDShooter.enums;
using TDShooter.Input;
using UnityEngine;

namespace TDShooter.Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class Grenade : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _maxThrowDistance;

        [SerializeField] private float _damage;
        [SerializeField] private float _explosionRadius;

        private SpawnAssistant _assistant;

        private bool _isExplosion;
        private float _timer;
        private void OnEnable()
        {
            ResetGrenadeTimer();
        }

        private void Start()
        {
            _assistant = FindObjectOfType<SpawnAssistant>();
        }

        private void ResetGrenadeTimer()
        {
            _lifeTime = 0.5f;
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

            float v = Mathf.Sqrt(Mathf.Abs((Physics.gravity.y * x * x) / (y - x) ));
            //transform.parent = null;
            Vector3 angle = fromTo.normalized + Vector3.up;
            GetComponent<Rigidbody>().velocity = angle.normalized * v;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer < 0 )
            {
                _isExplosion = true;
            }
        }
        public void Explode()
        {
            gameObject.SetActive(false);
            //âçðûâ
            var enemies = _assistant.EnemiesPool[ÑharacterType.FastMeleeEnemy].GetActiveUnits();
            enemies.AddRange(_assistant.EnemiesPool[ÑharacterType.Spider].GetActiveUnits());
            //todo äîáàâèòü îáùèé ñïèñîê âðàãîâ done
            enemies = enemies.Where(x => Vector3.Distance(x.transform.position, this.transform.position) < _explosionRadius).ToList();
            foreach (var enemy in enemies)
            {
                var character = enemy.GetComponent<Character>();
                character.Die();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_isExplosion)
            {
                if (collision.gameObject.GetComponentInParent<PlayerControl>() != null)
                {
                    return;
                }
                Explode();
               // Debug.Log("Boom!");
            }
            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (_isExplosion)
            {
                Explode();
                //Debug.Log("Boom!");
            }
        }
    }
}