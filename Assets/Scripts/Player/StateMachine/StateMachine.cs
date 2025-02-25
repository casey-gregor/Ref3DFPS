using DefaultNamespace;
using Player.StateMachine.SubStates;
using UnityEngine;
using Zenject;

namespace Player.StateMachine
{
    public class StateMachine : IInitializable
    {
        public State CurrentState { get; private set; }
        public State PastState { get; private set; }
        
        public IdleState IdleState { get; protected set; }
        public MoveState MoveState { get; protected set; }
        public IdleJumpState IdleJumpState { get; protected set; }
        public MoveJumpState MoveJumpState { get; protected set; }
        public InAirState InAirState { get; protected set; }
        public LandState LandState { get; protected set; }
        
        public CharacterController CharacterController {get; private set;}
        private readonly Animator _playerAnimator;
        private readonly InputController _inputController;

        public StateMachine(
            CharacterController characterController,
            Animator playerAnimator, 
            InputController inputController)
        {
            CharacterController = characterController;
            _playerAnimator = playerAnimator;
            _inputController = inputController;
        }
        
        public void Initialize()
        {
            
            IdleState = new IdleState("idleState", this, _playerAnimator, _inputController,"idle");
            MoveState = new MoveState("moveState", this, _playerAnimator, "walk");
            IdleJumpState = new IdleJumpState("idleJumpState", this, _playerAnimator, "idleJump");
            MoveJumpState = new MoveJumpState("moveJumpState", this, _playerAnimator, "moveJump");
            InAirState = new InAirState("inAirState", this, _playerAnimator, "inAir");
            LandState = new LandState("landState", this, _playerAnimator, "land");
            
            InitiateState(IdleState);
        }


        public void InitiateState(State state)
        {
            CurrentState = state;
            CurrentState.EnterState();
        }

        public void ChangeState(State newState)
        {
            if (CurrentState == newState)
                return;
            PastState = CurrentState;
            CurrentState.ExitState();
            CurrentState = newState;
            CurrentState.EnterState();
        }

        
    }
}