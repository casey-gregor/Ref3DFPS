using UnityEngine;

namespace Player.StateMachine.SubStates
{
    public class MoveJumpState : State
    {
        public MoveJumpState(
            string stateName, 
            StateMachine stateMachine, 
            Animator playerAnimator, 
            string animParamName = null) 
            : base(stateName, stateMachine, playerAnimator, animParamName)
        {
        }
    }
}