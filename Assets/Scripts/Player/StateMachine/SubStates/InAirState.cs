using UnityEngine;

namespace Player.StateMachine.SubStates
{
    public class InAirState : State
    {
        public InAirState(
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
            if (StateMachine.CharacterController.isGrounded)
            {
                StateMachine.ChangeState(StateMachine.LandState);
            }
        }
    }
}