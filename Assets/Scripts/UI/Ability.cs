using System.Collections;
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

        public void ScaleTime(float incomingValue)
        {
            StartCoroutine(TimeScale(incomingValue));
        }



        IEnumerator TimeScale(float timer)
        {
            _effectMarker.fillAmount = 0f;
            while (timer > 0)
            {
                yield return new WaitForSeconds(0.5f);
                _effectMarker.fillAmount += 0.1f;
                timer -= 0.1f;
            }
        }
    }
}
