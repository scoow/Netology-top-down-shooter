using UnityEngine;

namespace TDShooter.Effects
{
    public class BloodStain : MonoBehaviour
    {
        [SerializeField] BloodLifeTimer _bloodLifeTimer;

        public BloodLifeTimer BloodLifeTimer => _bloodLifeTimer;
    }
}