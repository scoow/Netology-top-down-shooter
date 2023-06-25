using UnityEngine;
using TDShooter.Weapons;
using TDShooter.UI;
using TDShooter.enums;
using TDShooter.Characters;
using Zenject;
using TDShooter.Configs;
using System;
using TDShooter.Managers;

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
        private Animator_Controller _animControl;
        [Inject]
        private readonly WeaponChanger _weaponChanger;
        [Inject]
        private readonly ProjectilesManager _projectilesManager;
        [Inject]
        private readonly PauseMenu_Controller _pauseMenu_Controller;
        [Inject]
        private readonly PlayerProgress _playerProgress;

        public Action<Vector2> OnMove;

        public float Speed { get => _speed; private set => _speed = value; }

        private void Awake()
        {
            _controls = new Controls();
        }
        private void OnEnable()
        {
            _controls.Player.Enable();
            _controls.Player.Shoot.started += contect => Fire();
            _controls.Player.Shoot.canceled += contect => StopFire();

            _controls.Player.WeaponSwitchMachineGun.performed += context => _weaponChanger.ChangeWeapon(WeaponType.Machinegun);
            _controls.Player.WeaponSwitchShotgun.performed += context => _weaponChanger.ChangeWeapon(WeaponType.Shothun);
            _controls.Player.WeaponSwitchPlasmaGun.performed += context => _weaponChanger.ChangeWeapon(WeaponType.Plasmagun);
            _controls.Player.WeaponSwitchBFG.performed += context => _weaponChanger.ChangeWeapon(WeaponType.BFG);
            _controls.Player.NextWeapon.performed += context => _weaponChanger.NextWeapon(context.ReadValue<Vector2>().y);

            _controls.Player.ThrowGrenade.performed += context => ThrowGrenade();

            _controls.Player.PauseGame.performed += context => _pauseMenu_Controller.ActivatePauseMenu();
            _controls.Player.NuclearBomb.performed += context => ActivateNuclearBomb();
        }
        private void Update()
        {
            AimCursor();
            Move();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }
        private void ActivateNuclearBomb()
        {
            _playerProgress.UseNuclearCharge();
        }

        private void Fire()
        {
            _weaponChanger.CurrentWeapon().Shoot();
        }
        private void StopFire()
        {
            _weaponChanger.CurrentWeapon().CancelShoot();
        }

        private void ThrowGrenade()
        {
            Grenade grenade = _projectilesManager.GrenadePool[GrenadeType.Explosive].GetAviableOrCreateNew();
            grenade.transform.SetPositionAndRotation(transform.position, transform.rotation);
            _ = _animControl.ThrowAnimationAsync();

            grenade.Throw(_aim.transform.position);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            if (_aim != null)
                Gizmos.DrawLine(_playerHead.transform.position, _aim.transform.position);
        }

        private void Move()
        {
            var inputValue = _controls.Player.WASD.ReadValue<Vector2>(); // записываем в локальную переменную значение Vector2 при вызове события WASD
            OnMove.Invoke(inputValue);
            _playerBody.Translate(inputValue.x * Time.deltaTime * _playerData.SpeedMove, 0, inputValue.y * Time.deltaTime * _playerData.SpeedMove); //перемещаем объект в плоскости X0Z            
            _animControl.Move(inputValue, _playerHead.transform.rotation);
        }
        public void AimCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                _aim.transform.position = raycastHit.point;

                Vector3 relativePos = raycastHit.point - transform.position;
                Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                rotation.x = 0f;
                rotation.z = 0f;
                _playerHead.transform.rotation = rotation;
            }
        }
    }
}