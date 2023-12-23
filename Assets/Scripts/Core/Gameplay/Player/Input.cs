using UnityEngine;

namespace Asteroids.Core.Gameplay.Player
{
    public struct Input
    {
        private InputControls input;

        public float Direction => input.Gameplay.Movement.ReadValue<Vector2>().y;
        public float Rotation => input.Gameplay.Movement.ReadValue<Vector2>().x;
        public bool DefoultAttack => input.Gameplay.DefaultAttack.triggered;
        public bool SpecialAttack => input.Gameplay.SpecialAttack.triggered;

        public Input(InputControls input)
        {
            this.input = input;
            input.Gameplay.Enable();
        }
    }
}
