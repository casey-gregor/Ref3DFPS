namespace Interfaces
{
    public interface IGameUpdateListener : IGameListener
    {
        public void OnUpdate(float deltaTime);
    }
}