namespace Asteroids.Core.Gameplay.Movement
{
    public struct DirectionMovementWithBorder
    {
        public float SpeedMove { get; private set; }
        public float SpeedRotation { get; private set; }
        public Vector Direction { get; private set; }

        public DirectionMovementWithBorder(float speedMove, float speedRotate, Vector direction)
        {
            SpeedMove = speedMove;
            SpeedRotation = speedRotate;
            Direction = direction;
        }
    }
}

