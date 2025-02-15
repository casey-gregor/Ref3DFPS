using UnityEngine;

namespace Player.StateMachine
{
    public class State
    {
        public StateMachine StateMachine {get; private set; }
        private readonly string _stateName;
        private readonly string _animParamName;
        private readonly Animator _playerAnimator;

        public State(
            string stateName, 
            StateMachine stateMachine,
            Animator playerAnimator, 
            string animParamName = null)
        {
            _stateName = stateName;
            StateMachine = stateMachine;
            _playerAnimator = playerAnimator;
            _animParamName = animParamName;
        }

        public virtual void EnterState()
        {
            DoChecks();
            if(_animParamName != null)
            {
                _playerAnimator.SetBool($"{_animParamName}", true);
            }
            // if(player.DebugForStatesEnterExit)
            //     Debug.Log($"state {stateName} entered");
        }

        public virtual void ExitState()
        {
            // if(player.DebugForStatesEnterExit)
            //     Debug.Log($"state {stateName} exited");
            if (_animParamName != null)
            {
                _playerAnimator.SetBool($"{_animParamName}", false);
            }
        }

        protected virtual void LogicUpdate(){}
        protected virtual void PhysicsUpdate() { }
        protected virtual void LateUpdate() { }
        protected virtual void DoChecks() { }
        
    }
}