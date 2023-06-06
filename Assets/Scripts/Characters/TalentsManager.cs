using System;
using System.Collections.Generic;
using TDShooter.enums;
using TDShooter.Managers;
using UnityEngine;
using Zenject;

namespace TDShooter.Characters
{
    public class TalentsManager : MonoBehaviour
    {
        [Inject]
        private readonly PlayerProgress _playerProgress;

        private readonly List<Talents> _talents = new();

        private void Awake()
        {
            foreach (Talents talent in Enum.GetValues(typeof(Talents)))
            {
                _talents.Add(talent);
            }
            
        }
        private void OnEnable()
        {
            _playerProgress.OnNextLevel += PickTwoRandomTalents;
        }

        private bool TryPickRandomTalent(out Talents? talent)
        {
            if (_talents.Count == 0)
            {
                talent = null;
                return false;
            }

            int randomTalentIndex = UnityEngine.Random.Range(0, _talents.Count - 1);
            talent = _talents[randomTalentIndex];
            _talents.RemoveAt(randomTalentIndex);

            //Debug.Log("�� �������� " + talent);
            return true;
        }
        public void PickTwoRandomTalents()
        {
            Talents? talentOne;
            Talents? talentTwo;
            TryPickRandomTalent(out talentOne);
            TryPickRandomTalent(out talentTwo);

            //�������� ��� ������� � UI. ����� ���� null
        }

        private void OnDisable()
        {
            _playerProgress.OnNextLevel -= PickTwoRandomTalents;
        }
    }
}