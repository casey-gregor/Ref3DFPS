using DefaultNamespace;
using Interfaces;
using UnityEngine;
using Unity.Cinemachine;

namespace Player
{
    public class PlayerCameraFollow : IGameFixedUpdateListener
    {
        private readonly Camera _camera;
        private readonly InputController _inputController;
        private readonly CharacterController _characterController;
        private readonly Transform _cameraAimObject;
        
        private InputAxis _xAxis;
        private InputAxis _yAxis;

        private readonly float _sensitivity = 0.5f;
        private float _mouseX;
        private float _mouseY;

        private Vector3 _lookAtVector;

        public PlayerCameraFollow(
            Camera camera,
            CharacterController characterController,
            Transform cameraAimObject,
            InputController inputProcessor)
        {
            _characterController = characterController;
            _cameraAimObject = cameraAimObject;
            _inputController = inputProcessor;
            _camera = camera;
        }


        public void OnFixedUpdate(float deltaTime)
        {
            CameraUpdate();
            // Debug.Log("look at vector : " + _lookAtVector);
            // Debug.Log("input look : " + _inputController.HorizontalLookAxis + " : " + _inputController.VerticalLookAxis);
        }
        
        private void CameraUpdate()
        {
            _mouseX = _inputController.HorizontalLookAxis * _sensitivity;
            _mouseY -= _inputController.VerticalLookAxis * _sensitivity; 
            _mouseY = Mathf.Clamp(_mouseY, -30f, 30f);
            
            _characterController.transform.Rotate(0, _mouseX, 0);
            _cameraAimObject.localEulerAngles = new Vector3(_mouseY, 0, 0);
        }
        
        
    }
}