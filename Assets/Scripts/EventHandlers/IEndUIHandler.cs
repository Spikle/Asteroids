using Asteroids.Core.Gameplay;
using EventBusSystem;

namespace Scripts
{
    public interface IEndUIHandler : IGlobalSubscriber
    {
        public void ShowEnd(int score);
        public void HideEnd();
    }
}
