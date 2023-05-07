using UnityEngine;
using TDShooter.Weapons;
using static UnityEngine.GraphicsBuffer;
using TDShooter.UI;
using Zenject;

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
        }

        private void Fire()
        {
            Debug.Log("Делаем выстрел");
            _weapon.Shoot();
        }

        private void Move()
        {
            var inputValio = _controls.Player.WASD.ReadValue<Vector2>(); // записываем в локальную переменную значение Vector2 при вызове события WASD
            _playerBody.Translate(inputValio.x * Time.deltaTime * _speed, 0, inputValio.y * Time.deltaTime * _speed); //перемещаем объект в плоскости X0Z
        }
        public void AimCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                _aim.transform.position = raycastHit.point;                
                _playerHead.transform.LookAt(raycastHit.point);               
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
            Debug.Log($"Я подобрал {lootName}");
        }

    }
}