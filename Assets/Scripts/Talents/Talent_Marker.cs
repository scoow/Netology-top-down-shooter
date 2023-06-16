using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using TDShooter.Characters;
using Cysharp.Threading.Tasks;

namespace TDShooter.Talents
{
    public class Talent_Marker : MonoBehaviour, IPointerClickHandler
    {

        [SerializeField] private Image _talentSprite;
        [SerializeField] private Text _talentDescription;
        [SerializeField] private Talent_Marker _otherTalent;
        [SerializeField] private TalentsManager _talentsManager;
        private Talents_Base _currentTalant;

        public async void EnableTalantView(Talents_Base talents_Base) //включаем спрайт и описание таланта
        {
            _currentTalant = talents_Base;
            _talentSprite.sprite = talents_Base.TalentSprite;
            _talentDescription.text = talents_Base.Description;
            transform.DOScale(Vector3.one, 0.5f);

            await UniTask.Delay(500);
            Time.timeScale = 0f;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _otherTalent.transform.DOScale(Vector3.zero, 0.5f);
            transform.DOScale(Vector3.zero, 0.5f);
            _currentTalant.ActivateTalant(); //активируем силу таланта по клику
            _talentsManager.RemoveTalant(_currentTalant.GetTalantType());

            Time.timeScale = 1f;
        }
    }
}