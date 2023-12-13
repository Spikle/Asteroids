namespace Scripts.UI
{
    public class MainUI : AbstractUICanvas, IStartUIHandler, IGameplayUIHandler, IEndUIHandler
    {
        private void Awake()
        {
            EventBusSystem.EventBus.Subscribe(this);
        }

        private void OnDestroy()
        {
            EventBusSystem.EventBus.Unsubscribe(this);
        }

        private void Start()
        {
            Open<StartMenu>();
        }

        public void ShowStart()
        {
            Open<StartMenu>();
        }

        public void HideStart()
        {
            Close<StartMenu>();
        }

        public void ShowGameplay()
        {
            Open<GameplayMenu>();
        }

        public void HideGameplay()
        {
            Close<GameplayMenu>();
        }

        public void ShowEnd(int score)
        {
            EndMenu menu = Open<EndMenu>();
            menu.Init(score);
        }

        public void HideEnd()
        {
            Close<EndMenu>();
        }
    }
}