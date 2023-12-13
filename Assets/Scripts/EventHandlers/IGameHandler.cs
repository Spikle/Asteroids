using EventBusSystem;

namespace Scripts
{
    public interface IGameHandler : IGlobalSubscriber
    {
        public void StartGame();
    }
}
