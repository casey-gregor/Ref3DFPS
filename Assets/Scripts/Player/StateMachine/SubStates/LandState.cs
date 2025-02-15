using UnityEngine;

namespace Player.StateMachine.SubStates
{
    public class LandState : State
    {
        public LandState(
            string stateName, 
            StateMachine stateMachine, 
            Animator playerAnimator, 
            string animParamName = null) 
            : base(stateName, stateMachine, playerAnimator, animParamName)
        {
        }

        protected override void LogicUpdate()
        {
            base.LogicUpdate();
            
        }
    }
}