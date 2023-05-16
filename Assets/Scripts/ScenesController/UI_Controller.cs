using UnityEngine;
using UnityEngine.UI;

namespace TDShooter
{
    public class UI_Controller : MonoBehaviour
    {
        [SerializeField] Text _currentKills;
        [SerializeField] Text _targetKills;
        [SerializeField] Text _levelValue; //доделать увеличение уровня при достижении цели        

        internal void UpdateView(int incomingValue, UpdateViewType viewType )
        {
            switch (viewType)
            {
                case UpdateViewType.CurrentKills:
                    _currentKills.text = incomingValue.ToString();
                    break;
                case UpdateViewType.TargetKills:
                    _targetKills.text = incomingValue.ToString();
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