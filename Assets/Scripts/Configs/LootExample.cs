using System.Collections.Generic;
using TDShooter.enums;
using TDShooter.Input;
using UnityEngine;
using TDShooter.Configs;

namespace TDShooter
{
    public class LootExample : MonoBehaviour
    {
        private List<LootData_SO> _arrayLootData_SO;
        [SerializeField] private SpriteRenderer _spriteCurrentLoot;        
        //private EffectType _currentEffectType;        
        //private float _currentEffectTime;
        private LootData_SO _currentLoot;


        private void Awake()
        {
            _arrayLootData_SO = FindAnyObjectByType<LootController>().Loots;
        }

        private void OnEnable()
        {            
            _currentLoot = _arrayLootData_SO[Random.Range(0, _arrayLootData_SO.Capacity)];
            _spriteCurrentLoot.sprite = _currentLoot.SpriteLoot;
            //_currentEffectType = currentLootData_SO.EffectType;            
            //_currentEffectTime = currentLootData_SO.EffectTime;
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