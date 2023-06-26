using System;
using System.Collections.Generic;
using TDShooter.enums;
using TDShooter.EventManager;
using TDShooter.Managers;
using TDShooter.Talents;
using UnityEngine;
using Zenject;

namespace TDShooter.Characters
{
    public class TalentsManager : MonoBehaviour, IEventListener
    {
/*        [Inject]
        private readonly PlayerProgress _playerProgress;*/
        [Inject]
        private readonly Talent_Controller _talentControll;

        private readonly List<TalentType> _talents = new();

        private void Awake()
        {
            foreach (TalentType talent in Enum.GetValues(typeof(TalentType)))
            {
                _talents.Add(talent);
            }
        }
/*        private void OnEnable()
        {
            _playerProgress.OnNextLevel += PickTwoRandomTalents;
        }*/

        private bool TryPickRandomTalent(out TalentType? talent)
        {
            if (_talents.Count == 0)
            {
                talent = null;
                return false;
            }

            int randomTalentIndex = UnityEngine.Random.Range(0, _talents.Count - 1);
            talent = _talents[randomTalentIndex];

            return true;
        }

        public void RemoveTalant(TalentType talent)
        {
            _talents.Remove(talent);   
        }
        public void PickTwoRandomTalents()
        {
            TryPickRandomTalent(out TalentType? talentOne);
            TryPickRandomTalent(out TalentType? talentTwo);

            _talentControll.EnableTalent(talentOne, talentTwo); //передаём два таланта в UI. Могут быть null
        }

/*        private void OnDisable()
        {
            _playerProgress.OnNextLevel -= PickTwoRandomTalents;
        }*/

        public void OnEvent(GameEventType eventType, Component sender, UnityEngine.Object param = null)
        {
            PickTwoRandomTalents();
        }
    }
}