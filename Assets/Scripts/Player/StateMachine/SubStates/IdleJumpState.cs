using UnityEngine;

namespace Player.StateMachine.SubStates
{
    public class IdleJumpState : State
    {
        public IdleJumpState(
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
            StateMachine.ChangeState(StateMachine.InAirState);
        }
    }
}