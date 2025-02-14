using Movement;

namespace Zenject
{
    public class ComponentsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MoveComponent>().AsSingle();
            Container.Bind<JumpComponent>().AsSingle();
        }
    }
}