using System;
using Helpers;
using Player;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace Zenject
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Animator animator;
        [SerializeField] private AnimationEventDispatcher animationEventDispatcher;
        [SerializeField] private Transform cameraFollowObject;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private float playerSpeed;
        [SerializeField] private float playerJumpHeight;
        [SerializeField] private float gravity;
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerMoveComponent>()
                .AsSingle()
                .WithArguments(characterController, playerSpeed);
            
            Container
                .BindInterfacesAndSelfTo<PlayerJumpComponent>()
                .AsSingle()
                .WithArguments(characterController, animationEventDispatcher, playerJumpHeight, gravity);
            
            Container
                .BindInterfacesAndSelfTo<PlayerAnimationComponent>()
                .AsSingle()
                .WithArguments(animator, characterController);

            Container
                .BindInterfacesAndSelfTo<PlayerCameraFollow>()
                .AsSingle()
                .WithArguments(mainCamera, characterController, cameraFollowObject);
        }
    }
}