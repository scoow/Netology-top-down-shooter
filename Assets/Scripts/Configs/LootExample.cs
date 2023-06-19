using UnityEngine;
using TDShooter.Configs;
using DG.Tweening;

namespace TDShooter
{
    public class LootExample : MonoBehaviour
    {
        private LootData_SO _LootData_SO;
        [SerializeField] private SpriteRenderer _loot_MiniMap;
        [SerializeField] private SpriteRenderer _loot_Ground;
        private RectTransform _lootScale;

        private void Awake()
        {
            _lootScale = _loot_Ground.GetComponent<RectTransform>();
        }

        public void LoadLootData(LootData_SO lootData_SO)
        {
            _LootData_SO = lootData_SO;
            _loot_MiniMap.sprite = _loot_Ground.sprite = _LootData_SO.SpriteLoot;
            _lootScale.DOScale(5, 1).SetLoops(-1, LoopType.Yoyo);
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