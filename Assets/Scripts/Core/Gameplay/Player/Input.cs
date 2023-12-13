namespace Asteroids.Core.Gameplay.Player
{
    public struct Input
    {
        public float Direction { get; private set; }
        public float Rotation { get; private set; }
        public bool DefoultAttack { get; private set; }
        public bool SpecialAttack { get; private set; }

        public Input(float direction, float rotation)
        {
            Direction = direction;
            Rotation = rotation;
            DefoultAttack = false;
            SpecialAttack = false;
        }

        public Input(float direction, float rotation, bool defoultAttack, bool specialAttack)
        {
            Direction = direction;
            Rotation = rotation;
            DefoultAttack = defoultAttack;
            SpecialAttack = specialAttack;
        }
    }
}
