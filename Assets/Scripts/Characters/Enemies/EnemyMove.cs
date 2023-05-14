using TDShooter.Input;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace TDShooter.Enemies
{    
    public class EnemyMove : BaseUnit
    {
        [SerializeField] private Transform _target;
        //private Transform _currentTarget;
        [SerializeField] EnemyAttack _enemyAttack;

        [Tooltip("Величина стремления к цели"), SerializeField, Range(0f, 5f)]
        private float MaxVelocity;
        [Tooltip("Максимальная скорость перемещения"), SerializeField, Range(0f, 5f)]
        private float MaxSpeed;
        [Tooltip("Растояние начала прибытия"), SerializeField, Range(0.5f, 5f)]
        private float ArrivalDistance;
        [Tooltip("Дистанция до центра окружности блуждания"), SerializeField, Range(0.1f, 5f)]
        private float WanderCenterDistance;
        [Tooltip("Радиус окружности блуждания"), SerializeField, Range(0.1f, 5f)]
        private float WanderRadius;
        [Tooltip("Разброс угла блуждания"), SerializeField, Range(0f, 360f)]
        private float WanderAngleRange;

        private PlayerControl _playerControl;

        private void Awake()
        {
            //_playerControl = _target.GetComponent<PlayerControl>();
            _playerControl = FindObjectOfType<PlayerControl>();
            _target = _playerControl.transform;           
        }


        private void Update()
        {

            OnArrival();
            float distance = Vector3.Distance(transform.position, _target.transform.position);
            if (distance > ArrivalDistance+5f)
            {
                MaxSpeed = 5f;
            }
            if(distance < ArrivalDistance)
            {
                MaxSpeed = 0f;
            }
        }



        public void SetNewTarget(Transform target)
        {
            _target = target;//переделать
        }

        //движение в сторону цели вариант 1
        public void OnSeek()
        {
            if (_target == null) return;
            transform.LookAt(_target.transform.position);

            //сила стремления к цели
            var desired_velocity = (_target.transform.position - transform.position).normalized * MaxVelocity;
            //коррекция движения от текущей цели к желаемой
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //учитываем ограничение по силе и массу
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, MaxSpeed);

            SetVelocity(velocity);
        }

        //движение от цели вариант 1
        public void OnFlee()
        {
            if (_target == null) return;
            
            //сила стремления к цели
            var desired_velocity = (transform.position - _target.transform.position).normalized * MaxVelocity;
            //коррекция движения от текущей цели к желаемой
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //учитываем ограничение по силе и массу
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, MaxSpeed);

            SetVelocity(velocity);
        }

        //замедление при достижении определённой дистанции до цели 
        public void OnArrival()
        {
            if (_target == null) return;
            transform.LookAt(_target.transform.position);
            //сила стремления к цели
            var desired_velocity = _target.transform.position - transform.position;
            //квадрат растояния до цели
            var sqrLength = desired_velocity.sqrMagnitude;

            if(sqrLength < ArrivalDistance * ArrivalDistance)
            {
                desired_velocity /= ArrivalDistance;
                if (desired_velocity.sqrMagnitude < 1.5f)
                {

                    desired_velocity.z =0f; desired_velocity.x = 0f;
                }
            }

            //коррекция движения от текущей цели к желаемой
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //учитываем ограничение по силе и массу
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, MaxSpeed);

            SetVelocity(velocity);         

        }

        //движение в сторону цели вариант 2
        public void OnPursuing()
        {
/*            if (_currentTarget != null)
            {
*//*                var newPos = _currentTarget.transform.position;
                newPos.y += 1f;
                _target.position = newPos;*//*


                transform.position = new Vector3(_currentTarget.position.x, transform.position.y, _currentTarget.position.z);
            }*/
                            

            if (_target == null) return;
            transform.LookAt(_target.transform.position);
            var propheticIndex = Vector3.Distance(transform.position, _target.transform.position)/* / _playerControl.Speed*/;
            var targetPosition = _target.transform.position + _playerControl.GetVelocity(IgnoreAxisType.Y)*propheticIndex;

            //сила стремления к цели
            var desired_velocity = (targetPosition - transform.position).normalized * MaxVelocity;
            //коррекция движения от текущей цели к желаемой
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //учитываем ограничение по силе и массу
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, MaxSpeed);

            SetVelocity(velocity);
            
        }

        //движение от цели вариант 2
        public void OnEvading()
        {

            if (_target == null) return;

            var propheticIndex = Vector3.Distance(transform.position, _target.transform.position)/* / _playerControl.Speed*/;
            var targetPosition = _target.transform.position + _playerControl.GetVelocity(IgnoreAxisType.Y) * propheticIndex;

            //сила стремления к цели
            var desired_velocity = (transform.position - targetPosition).normalized * MaxVelocity;
            //коррекция движения от текущей цели к желаемой
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //учитываем ограничение по силе и массу
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, MaxSpeed);

            SetVelocity(velocity);

        }

        //блуждание врага
        private void OnWander()
        {
            var center = GetVelocity(IgnoreAxisType.Y).normalized * WanderCenterDistance;

            var displacement = Vector3.zero;
            displacement.x = Mathf.Cos(WanderAngle * Mathf.Deg2Rad);
            displacement.z = Mathf.Sin(WanderAngle * Mathf.Deg2Rad);
            displacement = displacement.normalized * WanderRadius;

            WanderAngle += Random.Range(-WanderAngleRange, WanderAngleRange);

            //сила стремления к цели
            var desired_velocity = center + displacement;
            //коррекция движения от текущей цели к желаемой
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //учитываем ограничение по силе и массу
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, MaxSpeed);

            SetVelocity(velocity);
        }

    }
}
