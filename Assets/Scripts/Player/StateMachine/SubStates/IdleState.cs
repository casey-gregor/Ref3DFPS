using DefaultNamespace;
using Player.StateMachine.SuperStates;
using UnityEngine;

namespace Player.StateMachine.SubStates
{
    public class IdleState : State
    {
        private readonly InputReader _inputReader;

        public IdleState(
            string stateName, 
            StateMachine stateMachine, 
            Animator playerAnimator,
            InputReader inputReader,
            string animParamName = null) 
            : base(stateName, stateMachine, playerAnimator, animParamName)
        {
            _inputReader = inputReader;
        }
        
        protected override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_inputReader.MoveDirection == Vector2.zero)
            {
                if (_inputReader.JumpPressed)
                {
                    StateMachine.ChangeState(StateMachine.IdleJumpState);
                }
            }
            else
            {
                if (_inputReader.JumpPressed)
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