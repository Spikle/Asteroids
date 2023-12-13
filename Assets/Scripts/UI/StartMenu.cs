using UnityEngine.InputSystem;

namespace Scripts.UI
{
    public class StartMenu : AbstractMenuUI
    {
        private InputControls input;

        private void Awake()
        {
            input = new InputControls();
        }

        public override void Open()
        {
            input.UI.Enable();
            input.UI.Action.started += StartGame;
        }

        public void StartGame(InputAction.CallbackContext context)
        {
            if(context.phase == InputActionPhase.Started)
            {
                EventBusSystem.EventBus.RaiseEvent<IGameHandler>(h=> h.StartGame());
            }
        }

        public override void UpdateView()
        {

        }

        public override void Close()
        {
            input.UI.Action.started -= StartGame;
            input.UI.Disable();
            input.Dispose();
        }
    }
}

