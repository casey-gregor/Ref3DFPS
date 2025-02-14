using DefaultNamespace;
using Interfaces;
using Movement;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMoveComponent : IGameUpdateListener
    {
        private readonly CharacterController _characterController;
        private readonly InputReader _inputReader;
        private readonly float _playerSpeed;
        

        public PlayerMoveComponent(
            CharacterController characterController, 
            float playerSpeed, 
            InputReader inputReader)
        {
            _characterController = characterController;
            _inputReader = inputReader;
            _playerSpeed = playerSpeed;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_characterController.isGrounded)
            {
                Vector3 horizontalMovement = new Vector3(_inputReader.MoveDirection.x, 0, _inputReader.MoveDirection.y);
                _characterController.Move(horizontalMovement * (_playerSpeed * deltaTime));
            }
        }
    }
}