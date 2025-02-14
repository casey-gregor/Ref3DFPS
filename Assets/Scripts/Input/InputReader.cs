using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace DefaultNamespace
{
    public class InputReader : IInitializable, IDisposable
    {
        public Vector2 MoveDirection {get; private set;}
        
        public float HorizontalLookAxis {get; private set;}
        public float VerticalLookAxis {get; private set;}
        
        public bool FirePressed {get; private set;}
        
        public bool WeaponZoomPressed {get; private set;}
        
        public bool JumpPressed {get; private set;}
        
        public bool RunPressed {get; private set;}
        
        public float CycleWeaponInput {get; private set;}
        public bool NextWeaponPressed {get; private set;}
        public bool PreviousWeaponPressed {get; private set;}
        
        public bool PausePressed {get; private set;}

        private readonly InputAction _moveAction;
        private readonly InputAction _lookAction;
        private readonly InputAction _jumpAction;
        private readonly InputAction _runAction;
        private readonly InputAction _fireAction;
        private readonly InputAction _weaponZoomAction;
        private readonly InputAction _nextWeaponAction;
        private readonly InputAction _previousWeaponAction;
        private readonly InputAction _cycleWeaponAction;
        private readonly InputAction _pauseAction;
        

        [Inject]
        public InputReader(PlayerInput playerInput)
        {
            _moveAction = playerInput.actions["Move"];
            _lookAction = playerInput.actions["Look"];
            _jumpAction = playerInput.actions["Jump"];
            _runAction = playerInput.actions["Run"];
            _fireAction = playerInput.actions["Fire"];
            _weaponZoomAction = playerInput.actions["WeaponZoomIn"];
            _nextWeaponAction = playerInput.actions["NextWeapon"];
            _previousWeaponAction = playerInput.actions["PreviousWeapon"];
            _cycleWeaponAction = playerInput.actions["CycleWeapon"];
            _pauseAction = playerInput.actions["Pause"];
        }
        
        public void Initialize()
        {
            _moveAction.performed += ReadMovementInput;
            _moveAction.canceled += ResetMovementInput;
            _lookAction.performed += ReadLookInput;
            _jumpAction.performed += ReadJumpInput;
            _jumpAction.canceled += ResetJumpInput;
            _runAction.performed += ReadRunInput;
            _fireAction.performed += ReadFireInput;
            _weaponZoomAction.performed += ReadWeaponZoomInput;
            _nextWeaponAction.performed += ReadNextWeaponInput;
            _previousWeaponAction.performed += ReadPreviousWeaponInput;
            _cycleWeaponAction.performed += ReadCycleWeaponInput;
            _pauseAction.performed += ReadPauseInput;
        }

        public void Dispose()
        {
            _moveAction.performed -= ReadMovementInput;
            _moveAction.canceled -= ResetMovementInput;
            _lookAction.performed -= ReadLookInput;
            _jumpAction.canceled -= ResetJumpInput;
            _jumpAction.performed -= ReadJumpInput;
            _runAction.performed -= ReadRunInput;
            _fireAction.performed -= ReadFireInput;
            _weaponZoomAction.performed -= ReadWeaponZoomInput;
            _nextWeaponAction.performed -= ReadNextWeaponInput;
            _previousWeaponAction.performed -= ReadPreviousWeaponInput;
            _cycleWeaponAction.performed -= ReadCycleWeaponInput;
            _pauseAction.performed -= ReadPauseInput;
        }

        private void ReadMovementInput(InputAction.CallbackContext context)
        {
            MoveDirection = context.ReadValue<Vector2>();
        }

        private void ResetMovementInput(InputAction.CallbackContext context)
        {
            MoveDirection = Vector2.zero;
        }

        private void ReadLookInput(InputAction.CallbackContext context)
        {
            Vector2 inputVector = context.ReadValue<Vector2>();
            HorizontalLookAxis = inputVector.x;
            VerticalLookAxis = inputVector.y;
        }
        
        private void ReadJumpInput(InputAction.CallbackContext context)
        {
            JumpPressed = !context.canceled;
        }

        private void ResetJumpInput(InputAction.CallbackContext context)
        {
            JumpPressed = false;
        }
        
        private void ReadRunInput(InputAction.CallbackContext context)
        {
            RunPressed = !context.canceled;
        }

        private void ReadFireInput(InputAction.CallbackContext context)
        {
            FirePressed = !context.canceled;
        }
        
        private void ReadWeaponZoomInput(InputAction.CallbackContext context)
        {
            WeaponZoomPressed = !context.canceled;
        }
        
        private void ReadNextWeaponInput(InputAction.CallbackContext context)
        {
            NextWeaponPressed = !context.canceled;
        }
        
        private void ReadPreviousWeaponInput(InputAction.CallbackContext context)
        {
            PreviousWeaponPressed = !context.canceled;
        }
        
        private void ReadCycleWeaponInput(InputAction.CallbackContext context)
        {
            Vector2 mouseScrollInput = context.ReadValue<Vector2>();
            if (mouseScrollInput.y == 0)
            {
                CycleWeaponInput = 0;
            }
            else
            {
                CycleWeaponInput = Mathf.Sign(mouseScrollInput.y);
            }
        }
        
        private void ReadPauseInput(InputAction.CallbackContext context)
        {
            PausePressed = !context.canceled;
        }
    }
}