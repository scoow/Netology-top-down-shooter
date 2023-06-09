using TDShooter.Input;
using UnityEngine;
using TDShooter.Characters;
using TDShooter.enums;

namespace TDShooter.Enemies
{    
    public class EnemyMove : BaseUnit
    {
        [SerializeField] private Transform _target;
        [SerializeField] EnemyAttack _enemyAttack;
       /* [SerializeField] */Animation_Controller _animationController;

        [Tooltip("�������� ���������� � ����"), SerializeField, Range(0f, 5f)]
        private float MaxVelocity;
        [Tooltip("������������ �������� �����������"), SerializeField, Range(0f, 5f)]
        private float _maxSpeed;
        [Tooltip("��������� ������ ��������"), SerializeField, Range(0.5f, 5f)]
        private float ArrivalDistance;
        [Tooltip("��������� �� ������ ���������� ���������"), SerializeField, Range(0.1f, 5f)]
        private float WanderCenterDistance;
        [Tooltip("������ ���������� ���������"), SerializeField, Range(0.1f, 5f)]
        private float WanderRadius;
        [Tooltip("������� ���� ���������"), SerializeField, Range(0f, 360f)]
        private float WanderAngleRange;
        private PlayerControl _playerControl;
        private void Awake()
        {
            _animationController = GetComponentInChildren<Animation_Controller>();
        }
        public void InjectPlayerControlReference(PlayerControl playerControl)
        {
            _playerControl = playerControl;
        }

        public float MaxSpeed => _maxSpeed;
        public void SetMaxSpeed(float maxSpeed)
        {
            _maxSpeed = maxSpeed;
        }    

        protected override void Start()
        {
            base.Start();
            _playerControl = FindObjectOfType<PlayerControl>();//�������� ����� ���������
            SetNewTarget(_playerControl.transform);
        }
        private void Update()//������� ����������� � ������������ ����� ������
        {
            LookAtPlayer();
            OnArrival();
            CheckDIstanceAndStopIfClose();
        }

        private void CheckDIstanceAndStopIfClose()//��� ��� ���
        {
            if (_target == null) return;
            float distance = Vector3.Distance(transform.position, _target.position);
            if (distance > ArrivalDistance + 5f && _animationController.EnemyState != EnemyAnimationState.Death)
            {
                SetMaxSpeed(5f);//������ ���������� �����
            }
            if (distance < ArrivalDistance && _animationController.EnemyState != EnemyAnimationState.Death)
            {
                SetMaxSpeed(0f);
            }
        }

        private void LookAtPlayer()
        {
            if (_target != null)
            {
                transform.LookAt(_target);
            }
        }
        public void SetNewTarget(Transform target)
        {
            _target = target;
        }

        //�������� � ������� ���� ������� 1
        public void OnSeek()
        {
            if (_target == null) return;            
            transform.LookAt(_target);

            //���� ���������� � ����
            var desired_velocity = (_target.position - transform.position).normalized * MaxVelocity;
            //��������� �������� �� ������� ���� � ��������
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //��������� ����������� �� ���� � �����
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, _maxSpeed);

            SetVelocity(velocity);
        }

        //�������� �� ���� ������� 1
        public void OnFlee()
        {
            if (_target == null) return;
            
            //���� ���������� � ����
            var desired_velocity = (transform.position - _target.position).normalized * MaxVelocity;
            //��������� �������� �� ������� ���� � ��������
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //��������� ����������� �� ���� � �����
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, _maxSpeed);

            SetVelocity(velocity);
        }

        //���������� ��� ���������� ����������� ��������� �� ���� 
        public void OnArrival()
        {
            if (_target == null) return;
            //if (_animationController.EnemyState == EnemyAnimationState.Death) return;
            
            //���� ���������� � ����
            var desired_velocity = _target.position - transform.position;
            //������� ��������� �� ����
            var sqrLength = desired_velocity.sqrMagnitude;

            if(sqrLength < ArrivalDistance * ArrivalDistance)
            {
                desired_velocity /= ArrivalDistance;
                if (desired_velocity.sqrMagnitude < 1.5f)
                {

                    desired_velocity.z =0f; desired_velocity.x = 0f;
                }
            }

            //��������� �������� �� ������� ���� � ��������
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //��������� ����������� �� ���� � �����
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, _maxSpeed);

            SetVelocity(velocity);         

        }

        //�������� � ������� ���� ������� 2
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
            transform.LookAt(_target);
            var propheticIndex = Vector3.Distance(transform.position, _target.position)/* / _playerControl.Speed*/;
            var targetPosition = _target.position + _playerControl.GetVelocity(IgnoreAxisType.Y)*propheticIndex;

            //���� ���������� � ����
            var desired_velocity = (targetPosition - transform.position).normalized * MaxVelocity;
            //��������� �������� �� ������� ���� � ��������
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //��������� ����������� �� ���� � �����
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, _maxSpeed);

            SetVelocity(velocity);
            
        }

        //�������� �� ���� ������� 2
        public void OnEvading()
        {

            if (_target == null) return;

            var propheticIndex = Vector3.Distance(transform.position, _target.position)/* / _playerControl.Speed*/;
            var targetPosition = _target.position + _playerControl.GetVelocity(IgnoreAxisType.Y) * propheticIndex;

            //���� ���������� � ����
            var desired_velocity = (transform.position - targetPosition).normalized * MaxVelocity;
            //��������� �������� �� ������� ���� � ��������
            var steering = desired_velocity - GetVelocity(IgnoreAxisType.Y);
            //��������� ����������� �� ���� � �����
            steering = Vector3.ClampMagnitude(steering, MaxVelocity) / Mass;

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, _maxSpeed);

            SetVelocity(velocity);

        }

        //��������� �����
        /*private void OnWander()
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

            var velocity = Vector3.ClampMagnitude(GetVelocity() + steering, _maxSpeed);

            SetVelocity(velocity);
        }*/
    }
}
