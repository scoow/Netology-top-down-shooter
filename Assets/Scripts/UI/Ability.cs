using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace TDShooter
{
    public class Ability : MonoBehaviour
    {
        private Image _effectMarker;

        private void Start()
        {
            _effectMarker = GetComponentInChildren<Effect_Marker>().GetComponent<Image>();
        }

        public async void ScaleTime(float incomingValue) //модифицируем здоровье
        {
            _effectMarker.fillAmount = 0f;
            var timer = incomingValue;            
            while (timer > 0)
            {                              
                await UniTask.Delay(1000);
                _effectMarker.fillAmount += 1/incomingValue;
                timer -= 1;
            }
        }
    }
}
