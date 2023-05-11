using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TDShooter
{
    public class PlayerProgress : MonoBehaviour
    {
        [SerializeField] private int _levelCount; //счЄтчик уровней
        [SerializeField] private int _currentKillsCount; //текущие убийства 
        [SerializeField] private int _targetKillsCount; //колиичество убийств дл€ повышени€ уровн€
        [SerializeField] private int _chanceDroopLoot; //шанс выпадени€ лута
        [SerializeField] private UI_Controller _controllerUI;
        public int ChanceDroopLoot => _chanceDroopLoot;

        public int LevelCount { get; private set; }       
        public int CurrentKilledCount
        {
            get => _currentKillsCount;
            set
            {
                if (value > 0)
                {
                    _currentKillsCount = value;
                    _controllerUI.UpdateView(_currentKillsCount, UpdateViewType.CurrentKills);
                    if (_currentKillsCount == _targetKillsCount)
                    {
                        _levelCount++;
                        _controllerUI.UpdateView(_levelCount, UpdateViewType.LevelUp);
                    }
                }

            }
        }
        public int TargetKilledCount
        {
            get => _targetKillsCount;
            set
            {
                if (value > 0)
                {
                    _targetKillsCount = value;
                    _controllerUI.UpdateView(_targetKillsCount,UpdateViewType.TargetKills);
                }

            }
        }


        private void Start()
        {
            _controllerUI.UpdateView(_targetKillsCount, UpdateViewType.TargetKills);
        }


        public int CheckChance()
        {
            return Random.Range(0, 100);
        }
    }
}
