using EventBusSystem;

namespace Scripts
{
    public interface IGameplayUIHandler : IGlobalSubscriber
    {
        public void ShowGameplay();
        public void HideGameplay();
    }
}

