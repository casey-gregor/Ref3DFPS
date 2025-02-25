using DefaultNamespace;
using Player.StateMachine.SuperStates;
using UnityEngine;

namespace Player.StateMachine.SubStates
{
    public class IdleState : State
    {
        private readonly InputController _inputController;

        public IdleState(
            string stateName, 
            StateMachine stateMachine, 
            Animator playerAnimator,
            InputController inputController,
            string animParamName = null) 
            : base(stateName, stateMachine, playerAnimator, animParamName)
        {
            _inputController = inputController;
        }
        
        protected override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_inputController.HorizontalDirection == Vector3.zero)
            {
                if (_inputController.JumpPressed)
                {
                    StateMachine.ChangeState(StateMachine.IdleJumpState);
                }
            }
            else
            {
                if (_inputController.JumpPressed)
                {
                    StateMachine.ChangeState(StateMachine.MoveJumpState);
                }
                else
                {
                    StateMachine.ChangeState(StateMachine.MoveState);
                }
            }

        }
    }
}