using UnityEngine;
using UnityEngine.UI;

namespace TDShooter
{
    public class UI_Controller : MonoBehaviour
    {
        [SerializeField] Text _currentKills;
        [SerializeField] Text _targetKills;
        [SerializeField] Text _levelValue; //доделать увеличение уровня при достижении цели
        [SerializeField] Slider _progressBarValue;


        internal void UpdateView(int incomingValue, UpdateViewType viewType )
        {
            switch (viewType)
            {
                case UpdateViewType.CurrentKills:
                    _currentKills.text = incomingValue.ToString();
                    _progressBarValue.value = incomingValue;
                    break;
                case UpdateViewType.TargetKills:
                    _targetKills.text = incomingValue.ToString();
                    _progressBarValue.maxValue = incomingValue;
                    break;
                case UpdateViewType.LevelUp:
                    _levelValue.text = incomingValue.ToString();
                    break;
            }
        }
    }
    public enum UpdateViewType
    {
        CurrentKills,
        TargetKills,
        LevelUp
    }
}