using DefaultNamespace;
using Interfaces;
using Movement;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMoveComponent : IGameUpdateListener
    {
        public Vector3 HorizontalDirection { get; private set; }
        private Vector3 _tempDirection;
        
        private readonly CharacterController _characterController;
        private readonly InputController _inputController;
        private readonly float _playerSpeed;
        

        public PlayerMoveComponent(
            CharacterController characterController, 
            float playerSpeed,
            InputController inputController)
        {
            _characterController = characterController;
            _playerSpeed = playerSpeed;
            _inputController = inputController;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_characterController.isGrounded)
            {
                AdjustHorizontalDirection();
                _characterController.Move(HorizontalDirection * (_playerSpeed * deltaTime));
            }
        }

        private void AdjustHorizontalDirection()
        {
            float speed = CheckIfRunning() ? 1 : 0.5f;
            _tempDirection.x = Mathf.Clamp(_inputController.HorizontalDirection.x, -speed, speed);
            _tempDirection.z = Mathf.Clamp(_inputController.HorizontalDirection.z, -speed, speed);
            HorizontalDirection = _tempDirection;
        }

        private bool CheckIfRunning()
        {
            return _inputController.RunPressed;
        }
    }
}