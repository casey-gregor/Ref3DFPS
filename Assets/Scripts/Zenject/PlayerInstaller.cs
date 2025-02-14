using System;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Zenject
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float playerSpeed;
        [SerializeField] private float playerJumpHeight;
        [SerializeField] private float gravity;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerMoveComponent>().AsSingle().WithArguments(characterController, playerSpeed);
            Container.BindInterfacesAndSelfTo<PlayerJumpComponent>().AsSingle().WithArguments(characterController, playerJumpHeight, gravity);
        }
    }
}