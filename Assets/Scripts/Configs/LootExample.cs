using UnityEngine;
using TDShooter.Configs;

namespace TDShooter
{
    public class LootExample : MonoBehaviour
    {
        private LootData_SO _LootData_SO;
        [SerializeField] private SpriteRenderer _loot_MiniMap;
        [SerializeField] private SpriteRenderer _loot_Ground;

        public void LoadLootData(LootData_SO lootData_SO)
        {
            _LootData_SO = lootData_SO;
            _loot_MiniMap.sprite = _loot_Ground.sprite = _LootData_SO.SpriteLoot;
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