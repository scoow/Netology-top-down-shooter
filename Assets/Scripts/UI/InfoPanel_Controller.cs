using Cysharp.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using TDShooter.Managers;
using Zenject;

namespace TDShooter.UI
{
    public class InfoPanel_Controller : MonoBehaviour
    {        
        [SerializeField] MesagePanel_Marker _mesagePanel;
        [SerializeField] Cursor_Marker _cursor;
        [Inject] 
        PlayerProgress _playerProgress;

        private void OnEnable()
        {
            _playerProgress.OnPortal += ShowInfo;
        }
        private void OnDisable()
        {
            _playerProgress.OnPortal -= ShowInfo;
        }


        private void ShowInfo()
        {
            //ActivateInfoPanel();            
            _cursor.gameObject.SetActive(true);
        }

        private async void ActivateInfoPanel()
        {
            _mesagePanel.gameObject.SetActive(true);
            _mesagePanel.transform.DOScale(1, 1);
            await UniTask.Delay(3000);
            _mesagePanel.transform.DOScale(0, 1);
            _mesagePanel.gameObject.SetActive(false);
        }
    }    
}