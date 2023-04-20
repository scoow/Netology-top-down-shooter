using UnityEngine;
using TDShooter.Weapons;

namespace TDShooter.Input
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] Transform _playerHead;
        [SerializeField] Transform _playerBody;
        private Controls _controls;
        [SerializeField]
        private float _speed;
        private Weapon _weapon;//ссылка на оружие игрока. В будующем убрать ссылку в отдельный класс Player
        [SerializeField]
        private SpriteRenderer _aim;
        

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
        private void AttachHeadToBody()
        {
            Vector3 position = _playerBody.position;
            position.y = 1.5f;
            _playerHead.position = position;
        }

        private void Update()
        {
            Move();
            //AttachHeadToBody();
            AimCursor();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }



    }
}