using UnityEngine;
using TDShooter.Weapons;
using static UnityEngine.GraphicsBuffer;

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
        private Aim_Marker _aim;
        

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
                _playerHead.transform.LookAt(/*new Vector3(raycastHit.point.x, _playerHead.transform.position.y,*/ raycastHit.point/*.z)*/);
                //_playerHead.transform.Rotate(90, 0, 0);

               /* var lookPos = raycastHit.point - _playerHead.transform.position;
                lookPos.y = 1;
                var rotation = Quaternion.LookRotation(lookPos);
                _playerHead.transform.rotation = rotation;*/
            }
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

    }
}