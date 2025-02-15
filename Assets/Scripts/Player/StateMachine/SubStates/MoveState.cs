using UnityEngine;

namespace Player.StateMachine.SubStates
{
    public class MoveState : State
    {
        public MoveState(
            string stateName, 
            StateMachine stateMachine, 
            Animator playerAnimator, 
            string animParamName = null) 
            : base(stateName, stateMachine, playerAnimator, animParamName)
        {
        }
    }
}