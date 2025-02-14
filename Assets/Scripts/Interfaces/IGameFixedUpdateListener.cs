namespace Interfaces
{
    public interface IGameFixedUpdateListener : IGameListener
    {
        public void OnFixedUpdate(float fixedDeltaTime);
    }
}