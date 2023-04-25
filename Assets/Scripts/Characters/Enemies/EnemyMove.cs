using TDShooter.Input;
using UnityEngine;


namespace TDShooter
{    
    public class EnemyMove : BaseUnit
    {
        [SerializeField] private Transform _target;

        [Tooltip("�������� ���������� � ����"), SerializeField, Range(1f, 5f)]
        public float MaxVelocity;
        [Tooltip("������������ �������� �����������"), SerializeField, Range(1f, 5f)]
        public float MaxSpeed;
        [Tooltip("��������� ������ ��������"), SerializeField, Range(0.5f, 5f)]
        public float ArrivalDistance;
        [Tooltip("��������� �� ������ ���������� ���������"), SerializeField, Range(0.1f, 5f)]
        public float WanderCenterDistance;
        [Tooltip("������ ���������� ���������"), SerializeField, Range(0.1f, 5f)]
        public float WanderRadius;
        [Tooltip("������� ���� ���������"), SerializeField, Range(0f, 360f)]
        public float WanderAngleRange;

        private PlayerControl _playerControl;

        private void Awake()
        {
            //_playerControl = _target.GetComponent<PlayerControl>();
            _playerControl = FindObjectOfType<PlayerControl>();
        }


        private void Update()
        {
            //OnSeek();
            //OnArrival();
            OnWander();
            //OnFlee();
            //OnPursuing();
            //OnEvading();
        }

        //�������� � ������� ���� ������� 1
        public void OnSeek()
        {
            if (_target == null) return;
            
            //���� ���������� � ����
            var desired_velocity = (_target.transform.position - transform.position).normalized * MaxVelocity;
            //��������� �������� �� ������� ���� � ��������
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //��������� ����������� �� ���� � �����
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, MaxSpeed);

            SetVelocity(velocity);
        }

        //�������� �� ���� ������� 1
        public void OnFlee()
        {
            if (_target == null) return;
            
            //���� ���������� � ����
            var desired_velocity = (transform.position - _target.transform.position).normalized * MaxVelocity;
            //��������� �������� �� ������� ���� � ��������
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //��������� ����������� �� ���� � �����
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, MaxSpeed);

            SetVelocity(velocity);
        }

        //���������� ��� ���������� ����������� ��������� �� ���� 
        public void OnArrival()
        {
            if (_target == null) return;
            
            //���� ���������� � ����
            var desired_velocity = _target.transform.position - transform.position;
            //������� ��������� �� ����
            var sqrLength = desired_velocity.sqrMagnitude;

            if(sqrLength > ArrivalDistance * ArrivalDistance)
            {
                desired_velocity = desired_velocity / ArrivalDistance;
                if (desired_velocity.sqrMagnitude < 1f)
                {
                    desired_velocity.z =0f; desired_velocity.x = 0f;
                }
            }

            //��������� �������� �� ������� ���� � ��������
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //��������� ����������� �� ���� � �����
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, MaxSpeed);

            SetVelocity(velocity);         

        }

        //�������� � ������� ���� ������� 2
        public void OnPursuing()
        {
            
            if (_target == null) return;

            var propheticIndex = Vector3.Distance(transform.position, _target.transform.position)/* / _playerControl.Speed*/;
            var targetPosition = _target.transform.position + _playerControl.GetVelocity(IgnoreAxisType.Y)*propheticIndex;

            //���� ���������� � ����
            var desired_velocity = (targetPosition - transform.position).normalized * MaxVelocity;
            //��������� �������� �� ������� ���� � ��������
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //��������� ����������� �� ���� � �����
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, MaxSpeed);

            SetVelocity(velocity);
            
        }

        //�������� �� ���� ������� 2
        public void OnEvading()
        {

            if (_target == null) return;

            var propheticIndex = Vector3.Distance(transform.position, _target.transform.position)/* / _playerControl.Speed*/;
            var targetPosition = _target.transform.position + _playerControl.GetVelocity(IgnoreAxisType.Y) * propheticIndex;

            //���� ���������� � ����
            var desired_velocity = (transform.position - targetPosition).normalized * MaxVelocity;
            //��������� �������� �� ������� ���� � ��������
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //��������� ����������� �� ���� � �����
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, MaxSpeed);

            SetVelocity(velocity);

        }

        //��������� �����
        private void OnWander()
        {
            var center = GetVelocity(IgnoreAxisType.Y).normalized * WanderCenterDistance;

            var displacement = Vector3.zero;
            displacement.x = Mathf.Cos(WanderAngle * Mathf.Deg2Rad);
            displacement.z = Mathf.Sin(WanderAngle * Mathf.Deg2Rad);
            displacement = displacement.normalized * WanderRadius;

            WanderAngle += Random.Range(-WanderAngleRange, WanderAngleRange);

            //���� ���������� � ����
            var desired_velocity = center + displacement;
            //��������� �������� �� ������� ���� � ��������
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //��������� ����������� �� ���� � �����
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, MaxSpeed);

            SetVelocity(velocity);
        }

    }
}
