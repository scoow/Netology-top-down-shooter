using Cysharp.Threading.Tasks;
using TDShooter.enums;
using TDShooter.Input;
using UnityEngine;
using UnityEngine.AI;

namespace TDShooter.Enemies
{
    public class Boss_Move : Enemy_NavMeshMove
    {          
        private int _spawnAssistAnimation;       

        private float _spawnAssistCoolDown = 30f;
        public float _spawnAssistTimer;
        private float _spawnAssistDuration = 10f;
        public float _spawnDurationTimer;
        private bool _isSpawn = false;


        protected override void Start()
        {     
            base.Start();
            _spawnAssistAnimation = Animator.StringToHash("Spawn");                      
            _spawnAssistTimer = _spawnAssistCoolDown;
            _spawnDurationTimer = _spawnAssistDuration;
        }

        protected override void Update()
        {
            base.Update(); 

            _spawnAssistTimer -= Time.deltaTime;            

            if(_spawnAssistTimer <0)
            {                
                _agent.speed = 0f;                
                _animator.SetBool(_attackAnimation, false);
                _animator.SetBool(_moveAnimation, false);
                _animator.SetBool(_spawnAssistAnimation, true);

                _spawnDurationTimer -= Time.deltaTime;
                if(_spawnDurationTimer < 0)
                {
                    _spawnAssistTimer = _spawnAssistCoolDown;
                    _spawnDurationTimer = _spawnAssistDuration;                    
                }
            }          
        }

        protected override void TryCheckDistance()
        {           
            if (!_isSpawn)
            {
                base.TryCheckDistance();
            }            
        }

        protected override void AnimationMove()
        {
            base.AnimationMove();
            _animator.SetBool(_spawnAssistAnimation, false);
        }

        protected override void AnimationAtack()
        {
            base.AnimationAtack();
            _animator.SetBool(_spawnAssistAnimation, false);
        }
    }
}