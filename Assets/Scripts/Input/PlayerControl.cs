using UnityEngine;
using TDShooter.Weapons;
using static UnityEngine.GraphicsBuffer;
using TDShooter.UI;
using Zenject;
using Cysharp.Threading.Tasks.Triggers;

namespace TDShooter.Input
{
    public class PlayerControl : BaseUnit
    {
        [SerializeField] Transform _playerHead;
        [SerializeField] Transform _playerBody;
        private Controls _controls;
        [SerializeField]
        private float _speed;
        private Weapon _weapon;//������ �� ������ ������. � �������� ������ ������ � ��������� ����� Player
                               // [SerializeField]
        [Inject]
        private Aim_Marker _aim;
        [SerializeField]
        private AudioSource _audioSourceSteps;
        [SerializeField]
        private AudioClip _oneShotSound;
        [SerializeField]
        private Animator_Controller _animControl;


        public float Speed { get => _speed; private set => _speed = value; } 

        private void Awake()
        {
            _controls = new Controls();
        }
        private void OnEnable()
        {
            _controls.Player.Enable();
            _controls.Player.Shoot.performed += contecxt => Fire();

            _weapon = GetComponentInChildren<Weapon>();
            //_animControl = GetComponent<Animator_Controller>();
        }

        private void Fire()
        {
            Debug.Log("������ �������");
            _weapon.Shoot();

            _audioSourceSteps.PlayOneShot(_oneShotSound);
        }

        private void Move()
        {
            var inputValio = _controls.Player.WASD.ReadValue<Vector2>(); // ���������� � ��������� ���������� �������� Vector2 ��� ������ ������� WASD
            _playerBody.Translate(inputValio.x * Time.deltaTime * _speed, 0, inputValio.y * Time.deltaTime * _speed); //���������� ������ � ��������� X0Z
            _animControl.Move(inputValio);
        }
        public void AimCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                _aim.transform.position = raycastHit.point;
                //_playerHead.transform.LookAt(raycastHit.point);
                Vector3 relativePos = raycastHit.point - transform.position;                
                Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                rotation.x = 0f;
                rotation.z = 0f;
                _playerHead.transform.rotation = rotation;

            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            if ( _aim != null ) 
                Gizmos.DrawLine(_playerHead.transform.position, _aim.transform.position);              
        }

        private void Update()
        {
            Move();
            AimCursor();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        public void TakeLoot(string lootName)
        {
            Debug.Log($"� �������� {lootName}");
        }

    }
}