using EventBusSystem;

namespace Scripts
{
    public interface IStartUIHandler : IGlobalSubscriber
    {
        public void ShowStart();
        public void HideStart();
    }
}

