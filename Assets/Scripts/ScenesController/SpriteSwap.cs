using UnityEngine;
using UnityEngine.UI;

namespace TDShooter.Audio
{
    public class SpriteSwap : MonoBehaviour
    {
        [SerializeField] Image _backGround;
        [SerializeField] Sprite _activeSprite;
        [SerializeField] Sprite _noActiveSprite;
        [SerializeField] Toggle _toggle;

        public void Swap()
        {
            if (_toggle.isOn)
            {
                _backGround.sprite = _activeSprite;
            }
            else
            {
                _backGround.sprite = _noActiveSprite;
            }
        }
    }
}