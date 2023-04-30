using System;
using UnityEngine;

namespace TDShooter.WinCondition
{
    /// <summary>
    /// Таймер
    /// </summary>
    public class Timer : MonoBehaviour//Возможно, сделать не монобехом
    {
        private DateTime _startTime = new();
        private DateTime _now = new();
        private TimeSpan _interval;
        /*[SerializeField]
        private Text _timerText;*/

        private void Start()
        {
            ResetTimer();
        }

        public void ResetTimer()
        {
            _startTime = DateTime.Now;
        }

        private void Update()
        {
            CalculateTimeElapsed();
            ConvertTimeElapsedToString();
            //_timerText.text = ConvertTimeElapsedToString();
        }

        private string ConvertTimeElapsedToString()
        {
            return _interval.Minutes + ":" + _interval.Seconds + ":" + _interval.Milliseconds / 100;
        }
        public float ConvertTimeElapsedToFloat()
        {
            return _interval.Minutes * 60 + _interval.Seconds + ((float)(_interval.Milliseconds / 100)) / 10;
        }

        private void CalculateTimeElapsed()
        {
            _now = DateTime.Now;
            _interval = _now - _startTime;
        }
    }
}