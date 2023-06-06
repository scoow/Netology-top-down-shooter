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
            _playerProgress.OnNextLevel += PickRandomTalent;
        }

        private void PickRandomTalent()
        {
            Debug.Log("Talent +1");
        }
        private void OnDisable()
        {
            _playerProgress.OnNextLevel -= PickRandomTalent;
        }
    }
}