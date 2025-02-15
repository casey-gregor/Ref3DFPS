using DefaultNamespace;
using Helpers;
using Interfaces;
using Movement;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerJumpComponent : IInitializable, ILateDisposable, IGameUpdateListener
    {
        private readonly CharacterController _characterController;
        private readonly AnimationEventDispatcher _animationEventDispatcher;
        private readonly InputReader _inputReader;
        
        private readonly float _jumpHeight;
        private readonly float _gravity;

        private bool _startJump;

        private Vector3 _velocity;
        
        public PlayerJumpComponent(
            CharacterController characterController,
            AnimationEventDispatcher animationEventDispatcher,
            InputReader inputReader,
            float jumpHeight,
            float gravity)
        {
            _characterController = characterController;
            _jumpHeight = jumpHeight;
            _inputReader = inputReader;
            _animationEventDispatcher = animationEventDispatcher;
            _gravity = gravity;
        }

        public void OnUpdate(float deltaTime)
        {
            if (!_characterController.isGrounded)
            {
                _velocity.y += _gravity * deltaTime;
            }
            else if (_velocity.y < 0)
            {
                _velocity.y = -2f;
            }

            _velocity = new Vector3(_characterController.velocity.x, _velocity.y, _characterController.velocity.z);
            _characterController.Move(_velocity * deltaTime);
            
            if (_characterController.isGrounded && _startJump)
            {
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
                _startJump = false;
            }
            
        }

        public void Initialize()
        {
            _animationEventDispatcher.AnimationTrigger += HandleAnimationTrigger;
        }
        
        public void LateDispose()
        {
            _animationEventDispatcher.AnimationTrigger -= HandleAnimationTrigger;
        }

        private void HandleAnimationTrigger()
        {
            _startJump = true;
        }
        
    }
}