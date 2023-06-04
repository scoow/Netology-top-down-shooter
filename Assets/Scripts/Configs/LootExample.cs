using UnityEngine;
using TDShooter.Configs;

namespace TDShooter
{
    public class LootExample : MonoBehaviour
    {
        private LootData_SO _LootData_SO;
        [SerializeField] private SpriteRenderer _spriteCurrentLoot;

        public void LoadLootData(LootData_SO lootData_SO)
        {
            _LootData_SO = lootData_SO;
            _spriteCurrentLoot.sprite = _LootData_SO.SpriteLoot;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player_Modify _player_Modify))
            {
                _player_Modify.TakeLoot(_LootData_SO);
                gameObject.SetActive(false);
            }            
        }
    }
}