using System;
using System.Collections.Generic;
using TDShooter.enums;
using UnityEngine;

namespace TDShooter.Characters
{
    public class TalentsManager : MonoBehaviour
    {
        private List<Talents> _talents = new List<Talents>();
        public event Action GetTalentPoint;
        private void Awake()
        {
            foreach (Talents talent in Enum.GetValues(typeof(Talents)))
            {
                _talents.Add(talent);
            }
        }
    }
}