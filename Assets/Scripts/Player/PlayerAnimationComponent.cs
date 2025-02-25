using DefaultNamespace;
using Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationComponent : IGameUpdateListener
    {
        private readonly Animator _animator;
        private readonly CharacterController _characterController;
        private readonly InputController _inputController;
        private PlayerMoveComponent _playerMoveComponent;

        public PlayerAnimationComponent(
            Animator animator,
            CharacterController characterController,
            InputController inputController, 
            PlayerMoveComponent playerMoveComponent)
        {
            _animator = animator;
            _characterController = characterController;
            _inputController = inputController;
            _playerMoveComponent = playerMoveComponent;
        }
        
        public void OnUpdate(float deltaTime)
        {
            CheckAnimationStates();
            SetAnimationBlendTreeFloats(deltaTime);
        }

        private void CheckAnimationStates()
        {
            if (_characterController.isGrounded)
            {
                ToggleIsGrounded(true);
                if (_inputController.HorizontalDirection == Vector3.zero)
                {
                    if (_inputController.JumpPressed)
                    {
                        SwitchOnIdleJump();
                        SwitchOffGroundMovement();
                    }
                    else
                    {
                        SwitchOnIdle();
                        SwitchOffJump();
                    }
                   
                }
                else if(_inputController.JumpPressed)
                {
                    SwitchOffGroundMovement();
                    SwitchOnMoveJump();
                }
                else
                {
                    SwitchOnWalk();
                }
            }
            else
            {
                ToggleIsGrounded(false);
                SwitchOffGroundMovement();
                SwitchOffJump();
            }
            
           
        }

        private void ToggleIsGrounded(bool value)
        {
            _animator.SetBool("isGrounded", value);
        }

        private void SwitchOnMoveJump()
        {
            _animator.SetBool("idleJump", false);
            _animator.SetBool("moveJump", true);
        }

        private void SwitchOnWalk()
        {
            _animator.SetBool("idle", false);
            _animator.SetBool("walk", true);
        }

        private void SwitchOffGroundMovement()
        {
            _animator.SetBool("idle", false);
            _animator.SetBool("walk", false);
        }

        private void SwitchOffJump()
        {
            _animator.SetBool("idleJump", false);
            _animator.SetBool("moveJump", false);
        }

        private void SwitchOnIdle()
        {
            _animator.SetBool("idle", true);
            _animator.SetBool("walk", false);
        }

        private void SwitchOnIdleJump()
        {
            _animator.SetBool("idleJump", true);
            _animator.SetBool("moveJump", false);
        }

        private void SetAnimationBlendTreeFloats(float deltaTime)
        {
            _animator.SetFloat("horizontal", _playerMoveComponent.HorizontalDirection.x, 0.1f, deltaTime);
            _animator.SetFloat("vertical", _playerMoveComponent.HorizontalDirection.z, 0.1f, deltaTime);
        }
    }
}