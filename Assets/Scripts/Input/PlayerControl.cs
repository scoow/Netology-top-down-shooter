using UnityEngine;
using TDShooter.Weapons;
using static UnityEngine.GraphicsBuffer;
using TDShooter.UI;
using Zenject;
using Cysharp.Threading.Tasks.Triggers;
using TDShooter.enums;

namespace TDShooter.Input
{
    public class PlayerControl : BaseUnit
    {
        [SerializeField] Transform _playerHead;
        [SerializeField] Transform _playerBody;
        private Controls _controls;
        [SerializeField]
        private float _speed;
        private Weapon _weapon;//ссылка на оружие игрока. В будующем убрать ссылку в отдельный класс Player
                               // [SerializeField]
        [Inject]
        private Aim_Marker _aim;
        [SerializeField]
        private AudioSource _audioSourceSteps;
        [SerializeField]
        private AudioClip _oneShotSound;
        [SerializeField]
        private Animator_Controller _animControl;
        private WeaponChanger _weaponChanger;

        //private DirectionState directionMove = DirectionState.Idle;


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
            _weaponChanger = FindObjectOfType<WeaponChanger>();
            //_animControl = GetComponent<Animator_Controller>();
            _controls.Player.WeaponSwitchMachineGun.performed += context => _weaponChanger.ChangeWeapon(WeaponType.Machinegun);
            _controls.Player.WeaponSwitchPlasmaGun.performed += context => _weaponChanger.ChangeWeapon(WeaponType.Plasmagun);
        }

        private void Fire()
        {
            //Debug.Log("Делаем выстрел");
            _weapon.Shoot();

            _audioSourceSteps.PlayOneShot(_oneShotSound);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            if (_aim != null)
                Gizmos.DrawLine(_playerHead.transform.position, _aim.transform.position);
        }

        private void Move()
        {
            var inputValio = _controls.Player.WASD.ReadValue<Vector2>(); // записываем в локальную переменную значение Vector2 при вызове события WASD
            Vector3 previosPosition = _playerBody.transform.position;
            _playerBody.Translate(inputValio.x * Time.deltaTime * _speed, 0, inputValio.y * Time.deltaTime * _speed); //перемещаем объект в плоскости X0Z
            Vector3 nextPosition = _playerBody.transform.position;
            //CheckDirectionMove(previosPosition, nextPosition, _aim.transform.position);

            _animControl.Move(inputValio/*, directionMove*/);
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

        /*private void CheckDirectionMove(Vector3 previosPos, Vector3 nextPos, Vector3 aimPos)
        {
            if ((aimPos.z > nextPos.z && previosPos.z < nextPos.z) || (aimPos.z < nextPos.z && previosPos.z > nextPos.z))
            {                
                directionMove = DirectionState.Forward;
                print("вперед");
            }
               
            else if ((aimPos.z > nextPos.z && previosPos.z > nextPos.z) || (aimPos.z < nextPos.z && previosPos.z < nextPos.z))
            {
                directionMove = DirectionState.Back;                
                print("назад");                
            }
            else
            {
                directionMove = DirectionState.Idle;
            }
        }*/

       

        private void Update()
        {
            AimCursor();
            Move();            
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        public void TakeLoot(string lootName)
        {
            Debug.Log($"Я подобрал {lootName}");
        }

    }

    public enum DirectionState
    {
        Idle,
        Forward,
        Back
    }
}