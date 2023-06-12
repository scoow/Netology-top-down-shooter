using System;
using System.Collections.Generic;
using TDShooter.enums;
using TDShooter.Managers;
using TDShooter.Talents;
using UnityEngine;
using Zenject;

namespace TDShooter.Characters
{
    public class TalentsManager : MonoBehaviour
    {
        [Inject]
        private readonly PlayerProgress _playerProgress;
        [Inject]
        private readonly Talent_Controller _talentControll;

        private /*readonly*/ List<TalentType> _talents = new();

        private void Awake()
        {
            foreach (TalentType talent in Enum.GetValues(typeof(TalentType)))
            {
                _talents.Add(talent);
            }
            
        }
        private void OnEnable()
        {
            _playerProgress.OnNextLevel += PickTwoRandomTalents;
        }

        private bool TryPickRandomTalent(out TalentType? talent)
        {
            if (_talents.Count == 0)
            {
                talent = null;
                return false;
            }

            int randomTalentIndex = UnityEngine.Random.Range(0, _talents.Count - 1);
            talent = _talents[randomTalentIndex];
            //_talents.RemoveAt(randomTalentIndex);

            //Debug.Log("Вы получили " + talent);
            return true;
        }

        public void RemoveTalant(TalentType talent)
        {
            foreach(TalentType _talent in _talents)
            {
                if(_talent == talent)
                {
                    _talents.Remove(_talent);
                    break;
                }                    
            }            
        }
        public void PickTwoRandomTalents()
        {
            TalentType? talentOne;
            TalentType? talentTwo;
            TryPickRandomTalent(out talentOne);
            TryPickRandomTalent(out talentTwo);

            _talentControll.EnableTalent(talentOne, talentTwo); //передать два таланта в UI. Могут быть null
        }

        private void OnDisable()
        {
            _playerProgress.OnNextLevel -= PickTwoRandomTalents;
        }
    }
}