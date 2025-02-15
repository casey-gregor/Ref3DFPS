using UnityEngine;

namespace Player.StateMachine.SuperStates
{
    public class GroundState : State
    {
        public GroundState(
            string stateName, 
            StateMachine stateMachine, 
            Animator playerAnimator, 
            string animParamName = null) 
            : base(stateName, stateMachine, playerAnimator, animParamName)
        {
        }

        public override void EnterState()
        {
            base.EnterState();
        }
    }
}