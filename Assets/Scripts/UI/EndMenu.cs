using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Asteroids.Core.Gameplay.Player;

namespace Scripts.UI
{
    public class EndMenu : AbstractMenuUI
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private InputControls input;

        private void Awake()
        {
            input = new InputControls();
        }

        public void Init(int score)
        {
            scoreText.text = score.ToString();
        }

        public override void Open()
        {
            input.UI.Enable();
            input.UI.Action.started += StartGame;
        }

        public void StartGame(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
            {
                EventBusSystem.EventBus.RaiseEvent<IGameHandler>(h => h.StartGame());
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

