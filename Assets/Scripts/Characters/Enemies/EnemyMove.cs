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


        private void Update()
        {
            //OnSeek();
            OnArrival();
            //OnFlee();
        }

        //�������� � ������� ����
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

        //�������� �� ����
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
    }
}
