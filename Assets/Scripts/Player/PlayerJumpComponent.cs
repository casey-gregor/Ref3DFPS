using DefaultNamespace;
using Interfaces;
using Movement;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerJumpComponent : IGameUpdateListener
    {
        private readonly InputReader _inputReader;
        private readonly CharacterController _characterController;
        
        private readonly float _jumpHeight;
        private readonly float _gravity;

        private Vector3 _velocity;
        
        public PlayerJumpComponent(
            CharacterController characterController, 
            float jumpHeight,
            float gravity,
            InputReader inputReader)
        {
            _characterController = characterController;
            _jumpHeight = jumpHeight;
            _inputReader = inputReader;
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
            
            if (_characterController.isGrounded && _inputReader.JumpPressed)
            {
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            }
            
        }
    }
}