using UnityEngine;
using TDShooter.Weapons;

namespace TDShooter.Input
{
    public class PlayerControl : MonoBehaviour
    {
        private Controls _controls;
        [SerializeField]
        private float _speed;
        private Weapon _weapon;//ссылка на оружие игрока. В будующем убрать ссылку в отдельный класс Player

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
            transform.Translate(inputValio.x * Time.deltaTime * _speed, 0, inputValio.y * Time.deltaTime * _speed); //перемещаем объект в плоскости X0Z
        }

        private void Update()
        {
            Move();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }
    }
}