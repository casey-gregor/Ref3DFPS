using DefaultNamespace;
using GameCycle;
using Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Zenject
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private PlayerInput playerInput;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ListenersStorage>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameManager>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<PlayerInput>().FromInstance(playerInput).AsSingle();
            Container.BindInterfacesAndSelfTo<InputController>().AsSingle().NonLazy();
        }
    }
}