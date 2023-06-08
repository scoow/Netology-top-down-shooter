using UnityEngine;
using UnityEngine.UI;

namespace TDShooter.UI
{
    public class Button_Controller : MonoBehaviour
    {
        [SerializeField] Image _default;
        [SerializeField] Sprite _active;
        [SerializeField] Sprite _noteActive;



        private void Start()
        {
            _default = GetComponent<Image>();
        }
        public void ActiveView()
        {
            _default.sprite = _noteActive;
        }

        public void NoteActiveView()
        {
            _default.sprite = _active;
        }
    }
}