namespace Asteroids.Core.Gameplay.Movement
{
    public struct DirectionMovementWithoutBorder
    {
        public float SpeedMove { get; private set; }
        public float SpeedRotation { get; private set; }
        public Vector Direction { get; private set; }

        public DirectionMovementWithoutBorder(float speedMove, float speedRotate, Vector direction)
        {
            SpeedMove = speedMove;
            SpeedRotation = speedRotate;
            Direction = direction;
        }
    }
}


