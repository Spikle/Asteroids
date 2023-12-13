using EventBusSystem;

namespace Scripts
{
    public interface IScoreUIHandler : IGlobalSubscriber
    {
        public void UpdateScore(int value);
    }
}
