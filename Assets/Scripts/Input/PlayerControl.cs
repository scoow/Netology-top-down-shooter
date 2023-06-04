using UnityEngine;
using TDShooter.Weapons;
using TDShooter.UI;
using TDShooter.enums;
using TDShooter.Characters;
using Zenject;
using Cysharp.Threading.Tasks;
using TDShooter.Configs;

namespace TDShooter.Input
{
    public class PlayerControl : BaseUnit
    {
        [SerializeField] Player_Data _playerData;
        [SerializeField] Transform _playerHead;
        [SerializeField] Transform _playerBody;
        private Controls _controls;
        [SerializeField]
        private float _speed;
        [Inject]
        private readonly Aim_Marker _aim;
        [SerializeField]
        private AudioSource _audioSourceSteps;
        [SerializeField]
        private AudioClip _oneShotSound;
        [SerializeField]
        private Animator_Controller _animControl;
        [Inject]
        private readonly WeaponChanger _weaponChanger;
        [Inject]
        private readonly ProjectilesManager _projectilesManager;

        //[SerializeField] private GameObject _grenade;       
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

           //_animControl = GetComponent<Animator_Controller>();
            _controls.Player.WeaponSwitchMachineGun.performed += context => _weaponChanger.ChangeWeapon(WeaponType.Machinegun);
            _controls.Player.WeaponSwitchPlasmaGun.performed += context => _weaponChanger.ChangeWeapon(WeaponType.Plasmagun);
            _controls.Player.ThrowGrenade.performed += context => ThrowGrenade();
        }

        private void Fire()
        {
            //_weapon.Shoot();
            _weaponChanger.CurrentWeapon().Shoot();

            _audioSourceSteps.PlayOneShot(_oneShotSound);
        }

        private void ThrowGrenade()
        {
            Grenade grenade = _projectilesManager.GrenadePool[GrenadeType.Explosive].GetAviableOrCreateNew();
            grenade.transform.SetPositionAndRotation(transform.position, transform.rotation);

            Cysharp.Threading.Tasks.UniTask throwing = _animControl.ThrowAnimationAsync();

            grenade.Throw(_aim.transform.position);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            if (_aim != null)
                Gizmos.DrawLine(_playerHead.transform.position, _aim.transform.position);
        }

        private void Move()//todo лишние переменные
        {
            var inputValue = _controls.Player.WASD.ReadValue<Vector2>(); // записываем в локальную переменную значение Vector2 при вызове события WASD
            //Vector3 previosPosition = _playerBody.transform.position;
            _playerBody.Translate(inputValue.x * Time.deltaTime * _playerData.SpeedMove /*_speed*/, 0, inputValue.y * Time.deltaTime * _playerData.SpeedMove/*_speed*/); //перемещаем объект в плоскости X0Z
            //Vector3 nextPosition = _playerBody.transform.position;
            //CheckDirectionMove(previosPosition, nextPosition, _aim.transform.position);

            _animControl.Move(inputValue, _playerHead.transform.rotation);
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
    }

/*    public enum DirectionState
    {
        Idle,
        Forward,
        Back
    }*/
}