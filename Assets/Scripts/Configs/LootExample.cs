//using System;
using System.Collections;
using System.Collections.Generic;
using TDShooter.enums;
using TDShooter.Input;
using UnityEngine;
using UnityEngine.UI;

namespace TDShooter
{
    public class LootExample : MonoBehaviour
    {
        private List<LootData_SO> _arreyLootData_SO;
        [SerializeField] private SpriteRenderer _spriteCurrentLoot;        
        private int _currentEffectIndex;
        private EffectType _currentEffectType;
        private string _currentLootName;
        //private LootData 


        private void OnEnable()
        {
            _arreyLootData_SO = FindAnyObjectByType<LootController>().Loots;
            _currentEffectIndex = Random.Range(0, _arreyLootData_SO.Capacity);            
            _spriteCurrentLoot.sprite = _arreyLootData_SO[_currentEffectIndex].SpriteLoot;
            _currentEffectType = _arreyLootData_SO[_currentEffectIndex].EffectType;
            _currentLootName = _arreyLootData_SO[_currentEffectIndex].LootName;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerControl playerControl))
            {
                playerControl.TakeLoot(_currentLootName);
                gameObject.SetActive(false);
            }            
        }
    }
}