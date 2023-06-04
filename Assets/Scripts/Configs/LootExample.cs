using System.Collections.Generic;
using UnityEngine;
using TDShooter.Configs;
using Zenject;

namespace TDShooter
{
    public class LootExample : MonoBehaviour
    {
        [Inject]
        private readonly LootController _lootController;
        private List<LootData_SO> _arrayLootData_SO;
        [SerializeField] private SpriteRenderer _spriteCurrentLoot;
        private LootData_SO _currentLoot;

        private void Awake()
        {
            _arrayLootData_SO = _lootController.Loots;
        }

        private void OnEnable()
        {            
            _currentLoot = _arrayLootData_SO[Random.Range(0, _arrayLootData_SO.Capacity)];
            _spriteCurrentLoot.sprite = _currentLoot.SpriteLoot;            ;
        }       


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player_Modify _player_Modify))
            {
                _player_Modify.TakeLoot(_currentLoot);
                gameObject.SetActive(false);
            }            
        }
    }
}