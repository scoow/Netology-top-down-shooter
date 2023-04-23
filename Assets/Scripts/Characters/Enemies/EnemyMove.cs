using UnityEngine;


namespace TDShooter
{    
    public class EnemyMove : BaseUnit
    {
        [SerializeField] private Transform _target;

        [Tooltip("Величина стремления к цели"), SerializeField, Range(1f, 5f)]
        public float MaxVelocity;
        [Tooltip("Максимальная скорость перемещения"), SerializeField, Range(1f, 5f)]
        public float MaxSpeed;
        [Tooltip("Растояние начала прибытия"), SerializeField, Range(0.5f, 5f)]
        public float ArrivalDistance;


        private void Update()
        {
            //OnSeek();
            OnArrival();
            //OnFlee();
        }

        //движение в сторону цели
        public void OnSeek()
        {
            if (_target == null) return;
            
            //сила стремления к цели
            var desired_velocity = (_target.transform.position - transform.position).normalized * MaxVelocity;
            //коррекция движения от текущей цели к желаемой
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //учитываем ограничение по силе и массу
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, MaxSpeed);

            SetVelocity(velocity);
        }

        //движение от цели
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
            
            //сила стремления к цели
            var desired_velocity = _target.transform.position - transform.position;
            //квадрат растояния до цели
            var sqrLength = desired_velocity.sqrMagnitude;

            if(sqrLength > ArrivalDistance * ArrivalDistance)
            {
                desired_velocity = desired_velocity / ArrivalDistance;
                if (desired_velocity.sqrMagnitude < 1f)
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
    }
}
