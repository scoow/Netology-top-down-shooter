using TDShooter.Characters;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TDShooter.enums;
using TDShooter.UI;

public class DeathPanel : BaseUI_Controller
{
    [SerializeField] private Character_Player _character_Player;
    [SerializeField] private Image _backGround;
    [SerializeField] private Text _afterDeadthMesage;
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    private void OnEnable()
    {
        _character_Player.OnDie += DeathPanelActive;
        _yesButton.onClick.AddListener(delegate { LoadScene(SceneExample.NewGame); });
        _noButton.onClick.AddListener(delegate { LoadScene(SceneExample.MainMenu); });
    }

    private void OnDisable()
    {
        _character_Player.OnDie -= DeathPanelActive;
        _yesButton.onClick.RemoveAllListeners();
        _noButton.onClick.RemoveAllListeners();
    }
    private void DeathPanelActive()
    {
        _afterDeadthMesage.DOColor(new Color32(255, 255, 255, 255), 2);
        _backGround.DOColor(new Color32(0,0,0,190),2).OnComplete(SetActive);
    }  

    private void SetActive()
    {
        _yesButton.gameObject.SetActive(true);
        _yesButton.gameObject.transform.DOScale(1,0.2f);
        _noButton.gameObject.SetActive(true);
        _noButton.gameObject.transform.DOScale(1,0.2f);
    }
}